using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.BL.Abstract
{
    // Generic servis arayüzü: Herhangi bir türde (generic) bir varlık (entity) üzerinde temel CRUD işlemlerini içerir.
    public interface IGenericServices<T> where T : class
    {
        // Yeni bir varlık ekler.
        void TAdd(T entity);

        // Belirli bir varlığı siler.
        void TDelete(T entity);

        // Varlığı günceller.
        void TUpdate(T entity);

        // Belirli bir varlığı ID'ye göre getirir.
        T TGetById(int id);

        // Tüm varlıkları listeleyen bir metot.
        List<T> TGetListAll();
    }
}
