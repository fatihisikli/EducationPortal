using AutoMapper;               // AutoMapper kütüphanesini içeren namespace
using EP.DTO.EducationDto;       // Eğitim kullanıcı veri transfer nesnelerini içeren namespace
using EP.EL;                     // Entity Layer, veritabanı nesnelerini içeren namespace

namespace EP.API.Mapping
{
    // AutoMapper konfigürasyonu için kullanılan sınıf
    public class EducationUserMapper : Profile
    {
        // Constructor: EducationUserMapper sınıfının bir örneği oluşturulduğunda, eşleme konfigürasyonları yapılır.
        public EducationUserMapper()
        {
            // EducationUser sınıfı ile UpdateEducationUser sınıfı arasında çift yönlü eşleme yapılır.
            CreateMap<EducationUser, UpdateEducationUser>().ReverseMap();

            // EducationUser sınıfı ile CreateEducationUser sınıfı arasında çift yönlü eşleme yapılır.
            CreateMap<EducationUser, CreateEducationUser>().ReverseMap();

            // EducationUser sınıfı ile GetEducationUser sınıfı arasında çift yönlü eşleme yapılır.
            CreateMap<EducationUser, GetEducationUser>().ReverseMap();

            // Eğer UpdateEducationUser ile GetEducationUser sınıfları aynı yapıdaysa, bu eşleme yapısını tekrarlamak gerekmez.
        }
    }
}
