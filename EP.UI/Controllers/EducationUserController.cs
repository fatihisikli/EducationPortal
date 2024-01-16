using EP.EL;                              // Entity Layer (EL) namespace
using EP.UI.Dtos.EducationDtos;          // Education ile ilgili DTO (Data Transfer Object) nesnelerini içeren namespace
using EP.UI.Dtos.EducationUserDtos;      // EducationUser ile ilgili DTO nesnelerini içeren namespace
using Microsoft.AspNetCore.Authorization; // Yetkilendirme işlemlerini içeren namespace
using Microsoft.AspNetCore.Identity;      // ASP.NET Core Identity kütüphanesini içeren namespace
using Microsoft.AspNetCore.Mvc;           // ASP.NET Core MVC (Model-View-Controller) kütüphanesini içeren namespace
using Microsoft.AspNetCore.Mvc.Rendering; // ASP.NET Core MVC için seçeneklerin oluşturulmasını içeren namespace
using Newtonsoft.Json;                   // JSON işlemleri için Newtonsoft.Json kütüphanesini içeren namespace
using System.Security.Claims;             // Kullanıcı kimlik bilgilerini içeren namespace
using System.Text;                        // Metin işlemleri için namespace
using System.Threading.Tasks;             // Asenkron operasyonlar için namespace

namespace EP.UI.Controllers
{
    [Authorize] // Bu Controller'a sadece yetkilendirilmiş kullanıcıların erişebileceğini belirtir.
    public class EducationUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; // HttpClient örneği oluşturmak için kullanılan factory sınıfı
        private readonly UserManager<AppUser> _userManager;     // ASP.NET Core Identity kullanıcı yönetimi için UserManager

        // Constructor: EducationUserController sınıfının bir örneği oluşturulduğunda, bir IHttpClientFactory ve UserManager bağımlılıklarını enjekte eder.
        public EducationUserController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        // Kullanıcının katıldığı eğitimleri listeleyen sayfa
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var id = await _userManager.FindByNameAsync(User.Identity.Name);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7114/api/Education");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEducationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        // Yeni eğitim kullanıcısı oluşturma sayfası
        [HttpGet]
        public async Task<IActionResult> CreateEducationUser()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7114/api/Education");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultEducationDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.EducationName,
                                                Value = x.EducationId.ToString()
                                            }).ToList();
            ViewBag.v = values2;

            EducationwithEducationUser educationwithEducationUser = new EducationwithEducationUser();
            educationwithEducationUser.resultEducationDto = values2;
            return View(educationwithEducationUser);
        }

        // Yeni eğitim kullanıcısı oluşturma işlemi
        [HttpPost]
        public async Task<IActionResult> CreateEducationUser(CreateEducationUserDto createEducationUserDto)
        {
            createEducationUserDto.Status = "Devam Ediyor";
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueid = value.Id;
            createEducationUserDto.AppUserId = valueid;
            createEducationUserDto.EducationDate = DateTime.Now;
            createEducationUserDto.PersonCount = "1";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createEducationUserDto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7114/api/EducationUser", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DevamEdenEgitimUser");
            }
            return View();
        }

        // Devam eden eğitimleri listeleyen sayfa
        [HttpGet]
        public async Task<IActionResult> DevamEdenEgitimUser()
        {
            var sorguid = await _userManager.FindByNameAsync(User.Identity.Name);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7114/api/EducationUser");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var allValues = JsonConvert.DeserializeObject<List<ResultEducationUserDto>>(jsonData);

            var matchingValues = allValues.Where(x => x.AppUserId == sorguid.Id).Where(x => x.Status == "Devam Ediyor").ToList();

            List<DevamEdenEgitimUserDto> devamEdenEgitimUserDtos = new List<DevamEdenEgitimUserDto>();
            foreach (var item in matchingValues)
            {
                DevamEdenEgitimUserDto devamEdenEgitimUserDto = new DevamEdenEgitimUserDto();
                devamEdenEgitimUserDto.EducationUserId = item.EducationUserId;
                devamEdenEgitimUserDto.AppUserId = item.AppUserId;
                devamEdenEgitimUserDto.PersonCount = item.PersonCount;
                devamEdenEgitimUserDto.EducationUserName = item.EducationUserName;
                devamEdenEgitimUserDto.EducationUserType = item.EducationUserType;
                devamEdenEgitimUserDto.EducationDate = item.EducationDate;
                devamEdenEgitimUserDto.Status = item.Status;
                devamEdenEgitimUserDtos.Add(devamEdenEgitimUserDto);
            }

            return View(devamEdenEgitimUserDtos);
        }

        // Devam eden eğitimi tamamlandı olarak işaretleme işlemi
        [HttpPost]
        public async Task<IActionResult> DevamEdenEgitimUser(UpdateEducationUserDto updateEducationUserDto)
        {
            updateEducationUserDto.Status = "Tamamlandı";
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueid = value.Id;
            updateEducationUserDto.AppUserId = valueid;
            updateEducationUserDto.EducationDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateEducationUserDto);
            var values = JsonConvert.DeserializeObject<DevamEdenEgitimUserDto>(jsonData);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7114/api/EducationUser", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", values);
            }
            return View(values);
        }

        // Tamamlanan eğitimleri listeleyen sayfa
        [HttpGet]
        public async Task<IActionResult> TamamlananEgitimUser()
        {
            var sorguid = await _userManager.FindByNameAsync(User.Identity.Name);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7114/api/EducationUser");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var allValues = JsonConvert.DeserializeObject<List<ResultEducationUserDto>>(jsonData);

            var matchingValues = allValues.Where(x => x.AppUserId == sorguid.Id).Where(x => x.Status == "Tamamlandı").ToList();

            List<TamamlananEgitimUserDto> tamamlananEgitimUserDtos = new List<TamamlananEgitimUserDto>();
            foreach (var item in matchingValues)
            {
                TamamlananEgitimUserDto tamamlananEgitimUserDto = new TamamlananEgitimUserDto();
                tamamlananEgitimUserDto.EducationUserId = item.EducationUserId;
                tamamlananEgitimUserDto.AppUserId = item.AppUserId;
                tamamlananEgitimUserDto.PersonCount = item.PersonCount;
                tamamlananEgitimUserDto.EducationUserName = item.EducationUserName;
                tamamlananEgitimUserDto.EducationUserType = item.EducationUserType;
                tamamlananEgitimUserDto.EducationDate = item.EducationDate;
                tamamlananEgitimUserDto.Status = item.Status;
                tamamlananEgitimUserDtos.Add(tamamlananEgitimUserDto);
            }

            return View(tamamlananEgitimUserDtos);
        }

        // Devam eden eğitimi tamamlandı olarak işaretleme işlemi
        public async Task<IActionResult> CompletedEducationUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7114/api/EducationUser/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DevamEdenEgitimUser");
            }
            return View();
        }

        public async Task<IActionResult> DeleteEducationUser(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7114/api/EducationUser/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DevamEdenEgitimUser");
            }
            return View();
        }



        public async Task<IActionResult> UpdateEducationUser(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7114/api/EducationUser/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEducationUserDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEducation(UpdateEducationUserDto updateEducationUserDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateEducationUserDto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7114/api/EducationUser", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
