using AutoMapper;            // Nesne eşleme işlemlerini sağlayan AutoMapper kütüphanesini içeren namespace
using EP.BL.Abstract;         // İş mantığı (business logic) katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.DAL.Abstact;         // Veritabanı erişim katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.DTO.EducationDto;    // Eğitim kullanıcı veri transfer nesnelerini içeren namespace
using EP.EL;                  // Entity Layer, veritabanı nesnelerini içeren namespace
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationUserController : ControllerBase
    {
        private readonly IEducationUserServices _educationUserServices;

        // Constructor: EducationUserController sınıfının bir örneği oluşturulduğunda, IEducationUserServices tipinde bir bağımlılığı enjekte eder.
        public EducationUserController(IEducationUserServices educationUserServices)
        {
            _educationUserServices = educationUserServices;
        }

        // HTTP GET isteği ile çağrılan bir action: Tüm eğitim kullanıcılarını listeleyen bir endpoint
        [HttpGet]
        public IActionResult EducationList()
        {
            var values = _educationUserServices.TGetListAll();
            return Ok(values);
        }

        // HTTP POST isteği ile çağrılan bir action: Yeni bir eğitim kullanıcısı oluşturan bir endpoint
        [HttpPost]
        public IActionResult CreateEducationUser(CreateEducationUser createEducationUser)
        {
            // Gelen verilerle yeni bir EducationUser nesnesi oluşturulur ve iş mantığı katmanına iletilir.
            EducationUser edcationUser = new EducationUser()
            {
                AppUserId = createEducationUser.AppUserId,
                EducationDate = createEducationUser.EducationDate,
                EducationUserName = createEducationUser.EducationUserName,
                EducationUserType = createEducationUser.EducationUserType,
                PersonCount = createEducationUser.PersonCount,
                Status = createEducationUser.Status,
            };

            _educationUserServices.TAdd(edcationUser);
            return Ok("Eğitim Kullanıcıya başarılı şekilde eklendi.");
        }

        // HTTP DELETE isteği ile çağrılan bir action: Belirli bir eğitim kullanıcısını silen bir endpoint
        [HttpDelete("{id}")]
        public IActionResult DeleteEducationUser(int id)
        {
            // Veritabanından belirli bir eğitim kullanıcı ID'sine sahip olanı bulup siler.
            var value = _educationUserServices.TGetById(id);
            _educationUserServices.TDelete(value);
            return Ok("Eğitim Kullanıcıdan başarılı bir şekilde silindi");
        }

        // HTTP PUT isteği ile çağrılan bir action: Belirli bir eğitim kullanıcısını güncelleyen bir endpoint
        [HttpPut]
        public IActionResult UpdateEducationUser(UpdateEducationUser updateEducationUser)
        {
            // Gelen verilerle güncellenecek EducationUser nesnesi oluşturulur ve iş mantığı katmanına iletilir.
            EducationUser educationUser = new EducationUser()
            {
                AppUserId = updateEducationUser.AppUserId,
                EducationDate = updateEducationUser.EducationDate,
                EducationUserId = updateEducationUser.EducationUserId,
                EducationUserName = updateEducationUser.EducationUserName,
                EducationUserType = updateEducationUser.EducationUserType,
                PersonCount = updateEducationUser.PersonCount,
                Status = updateEducationUser.Status,
            };
            _educationUserServices.TUpdate(educationUser);
            return Ok("Eğitim Kullanıcıda Başarılı Şekilde Güncellendi");
        }

        // HTTP GET isteği ile belirli bir eğitim kullanıcısını getiren bir endpoint
        [HttpGet("GetEducationUser")]
        public IActionResult GetEducationUser(int id)
        {
            var value = _educationUserServices.TGetById(id);
            return Ok(value);
        }

        // Özel bir senaryo için eklenen bir action: Belirli bir eğitimi tamamlanan olarak güncelleyen bir endpoint
        [HttpGet("{id}")]
        public IActionResult GetEducation(int id)
        {
            EP.EL.EducationUser value = _educationUserServices.TGetById(id);
            value.Status = "Tamamlandı";
            _educationUserServices.TUpdate(value);
            return Ok(value);
        }
    }
}
