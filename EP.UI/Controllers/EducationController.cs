using EP.UI.Dtos.EducationDtos;          // Education ile ilgili DTO (Data Transfer Object) nesnelerini içeren namespace
using EP.UI.Dtos.EducationUserDtos;      // EducationUser ile ilgili DTO nesnelerini içeren namespace
using Microsoft.AspNetCore.Authorization; // Yetkilendirme işlemlerini içeren namespace
using Microsoft.AspNetCore.Mvc;           // ASP.NET Core MVC (Model-View-Controller) kütüphanesini içeren namespace
using Newtonsoft.Json;                   // JSON işlemleri için Newtonsoft.Json kütüphanesini içeren namespace
using System.Security.Claims;             // Kullanıcı kimlik bilgilerini içeren namespace
using System.Text;                        // Metin işlemleri için namespace
using System.Threading.Tasks;             // Asenkron operasyonlar için namespace

namespace EP.UI.Controllers
{
    [AllowAnonymous] // Yetkilendirme olmadan erişilebilen bir Controller sınıfı olduğunu belirtir.
    public class EducationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; // HttpClient örneği oluşturmak için kullanılan factory sınıfı

        // Constructor: EducationController sınıfının bir örneği oluşturulduğunda, bir IHttpClientFactory bağımlılığını enjekte eder.
        public EducationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Eğitim listesini gösteren sayfa
        public async Task<IActionResult> Index()
        {
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

        // Yeni eğitim oluşturma sayfası
        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        // Yeni eğitim oluşturma işlemi
        [HttpPost]
        public async Task<IActionResult> CreateEducation(CreateEducationDto createEducationDto)
        {
            createEducationDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createEducationDto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7114/api/Education", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // Eğitimi silme işlemi
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7114/api/Education/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // Eğitimi güncelleme sayfası
        public async Task<IActionResult> UpdateEducation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7114/api/Education/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEducationDto>(jsonData);
                return View(values);
            }
            return View();
        }

        // Eğitimi güncelleme işlemi
        [HttpPost]
        public async Task<IActionResult> UpdateEducation(UpdateEducationDto updateEducationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateEducationDto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7114/api/Education", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
