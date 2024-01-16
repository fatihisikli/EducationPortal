using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Abstact
{
    // IGenericDal arayüzü, genel (generic) bir veritabanı erişim operasyonlarının tanımlandığı bir arayüzdür.
    public interface IGenericDal<T> where T : class
    {
        // Belirli bir varlığı veritabanına ekler.
        void Add(T entity);

        // Belirli bir varlığı veritabanından siler.
        void Delete(T entityt);

        // Var olan bir varlığı günceller.
        void Update(T entity);

        // Belirli bir varlığı ID'ye göre veritabanından getirir.
        T GetById(int id);

        // Tüm varlıkları veritabanında listeleyen bir metot.
        List<T> GetListAll();
    }
}
