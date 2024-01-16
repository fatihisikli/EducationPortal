using EP.BL.Abstract;         // İş mantığı (business logic) katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.DTO.EducationDto;    // Eğitim veri transfer nesnelerini içeren namespace
using EP.EL;                  // Entity Layer, veritabanı nesnelerini içeren namespace
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationServices _educationServices;

        // Constructor: EducationController sınıfının bir örneği oluşturulduğunda, IEducationServices tipinde bir bağımlılığı enjekte eder.
        public EducationController(IEducationServices educationServices)
        {
            _educationServices = educationServices;
        }

        // HTTP GET isteği ile çağrılan bir action: Tüm eğitimleri listeleyen bir endpoint
        [HttpGet]
        public IActionResult EducationList()
        {
            var values = _educationServices.TGetListAll();
            return Ok(values);
        }

        // HTTP POST isteği ile çağrılan bir action: Yeni bir eğitim oluşturan bir endpoint
        [HttpPost]
        public IActionResult CreateEducation(CreateEducation createEducation)
        {
            // Gelen verilerle yeni bir Education nesnesi oluşturulur ve iş mantığı katmanına iletilir.
            Education edcation = new Education()
            {
                EducationName = createEducation.EducationName,
                EducationPrice = createEducation.EducationPrice,
                EducationTime = createEducation.EducationTime,
                EducationType = createEducation.EducationType,
                Capacity = createEducation.Capacity,
                Status = createEducation.Status,
            };

            _educationServices.TAdd(edcation);
            return Ok("Eğitim başarılı şekilde eklendi.");
        }

        // HTTP DELETE isteği ile çağrılan bir action: Belirli bir eğitimi silen bir endpoint
        [HttpDelete("{id}")]
        public IActionResult DeleteEducation(int id)
        {
            // Veritabanından belirli bir eğitim ID'sine sahip olanı bulup siler.
            var value = _educationServices.TGetById(id);
            _educationServices.TDelete(value);
            return Ok("Eğitim başarılı bir şekilde silindi");
        }

        // HTTP PUT isteği ile çağrılan bir action: Belirli bir eğitimi güncelleyen bir endpoint
        [HttpPut]
        public IActionResult UpdateEducation(UpdateEducation updateEducation)
        {
            // Gelen verilerle güncellenecek Education nesnesi oluşturulur ve iş mantığı katmanına iletilir.
            Education education = new Education()
            {
                EducationId = updateEducation.EducationId,
                EducationName = updateEducation.EducationName,
                EducationPrice = updateEducation.EducationPrice,
                EducationTime = updateEducation.EducationTime,
                EducationType = updateEducation.EducationType,
                Capacity = updateEducation.Capacity,
                Status = updateEducation.Status,
            };
            _educationServices.TUpdate(education);
            return Ok("Eğitim Başarılı Şekilde Güncellendi");
        }

        // HTTP GET isteği ile belirli bir eğitimi getiren bir endpoint
        [HttpGet("{id}")]
        public IActionResult GetEducation(int id)
        {
            var value = _educationServices.TGetById(id);
            return Ok(value);
        }
    }
}