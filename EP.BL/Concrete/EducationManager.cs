using EP.BL.Abstract;       // İş mantığı (business logic) katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.DAL.Abstact;       // Veritabanı erişim katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.EL;                // Entity Layer, veritabanı nesnelerini içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.BL.Concrete
{
    // IEducationServices arayüzünü implemente eden ve Education sınıfı üzerindeki iş mantığı operasyonlarını yöneten sınıf.
    public class EducationManager : IEducationServices
    {
        private readonly IEducationDal _educationDal;

        // Constructor: EducationManager sınıfının bir örneği oluşturulduğunda, bir IEducationDal bağımlılığını enjekte eder.
        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        // Veritabanına yeni bir eğitim ekler.
        public void TAdd(Education entity)
        {
            _educationDal.Add(entity);
        }

        // Belirli bir eğitimi siler.
        public void TDelete(Education entityt)
        {
            _educationDal.Delete(entityt);
        }

        // Belirli bir eğitimi ID'ye göre getirir.
        public Education TGetById(int id)
        {
            return _educationDal.GetById(id);
        }

        // Tüm eğitimleri listeleyen bir metot.
        public List<Education> TGetListAll()
        {
            return _educationDal.GetListAll();
        }

        // Var olan bir eğitimi günceller.
        public void TUpdate(Education entity)
        {
            _educationDal.Update(entity);
        }
    }
}
