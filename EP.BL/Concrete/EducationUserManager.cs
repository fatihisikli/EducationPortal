using EP.BL.Abstract;       // İş mantığı (business logic) katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.DAL.Abstact;       // Veritabanı erişim katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.DAL.EntityFramework; // Entity Framework tabanlı veritabanı erişim katmanını içeren namespace
using EP.EL;                // Entity Layer, veritabanı nesnelerini içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.BL.Concrete
{
    // IEducationUserServices arayüzünü implemente eden ve EducationUser sınıfı üzerindeki iş mantığı operasyonlarını yöneten sınıf.
    public class EducationUserManager : IEducationUserServices
    {
        private readonly IEducationUserDal _educationUserDal;

        // Constructor: EducationUserManager sınıfının bir örneği oluşturulduğunda, bir IEducationUserDal bağımlılığını enjekte eder.
        public EducationUserManager(IEducationUserDal educationUserDal)
        {
            _educationUserDal = educationUserDal;
        }

        // Veritabanına yeni bir eğitim kullanıcısı ekler.
        public void TAdd(EducationUser entity)
        {
            _educationUserDal.Add(entity);
        }

        // Belirli bir eğitim kullanıcısını siler.
        public void TDelete(EducationUser entityt)
        {
            _educationUserDal.Delete(entityt);
        }

        // Belirli bir eğitim kullanıcısını ID'ye göre getirir.
        public EducationUser TGetById(int id)
        {
            return _educationUserDal.GetById(id);
        }

        // Tüm eğitim kullanıcılarını listeleyen bir metot.
        public List<EducationUser> TGetListAll()
        {
            return _educationUserDal.GetListAll();
        }

        // Var olan bir eğitim kullanıcısını günceller.
        public void TUpdate(EducationUser entity)
        {
            _educationUserDal.Update(entity);
        }
    }
}
