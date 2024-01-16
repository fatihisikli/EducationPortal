using AutoMapper;            // AutoMapper kütüphanesini içeren namespace
using EP.DTO.EducationDto;    // Eğitim veri transfer nesnelerini içeren namespace
using EP.EL;                  // Entity Layer, veritabanı nesnelerini içeren namespace

namespace EP.API.Mapping
{
    // AutoMapper konfigürasyonu için kullanılan sınıf
    public class EducationMapper : Profile
    {
        // Constructor: EducationMapper sınıfının bir örneği oluşturulduğunda, eşleme konfigürasyonları yapılır.
        public EducationMapper()
        {
            // Education sınıfı ile UpdateEducation sınıfı arasında çift yönlü eşleme yapılır.
            CreateMap<Education, UpdateEducation>().ReverseMap();

            // Education sınıfı ile CreateEducation sınıfı arasında çift yönlü eşleme yapılır.
            CreateMap<Education, CreateEducation>().ReverseMap();

            // Education sınıfı ile GetEducation sınıfı arasında çift yönlü eşleme yapılır.
            CreateMap<Education, GetEducation>().ReverseMap();

            // Eğer UpdateEducation ile GetEducation sınıfları aynı yapıdaysa, bu eşleme yapısını tekrarlamak gerekmez.

        }
    }
}