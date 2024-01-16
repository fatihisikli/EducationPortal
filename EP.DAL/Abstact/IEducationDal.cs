using EP.EL;                 // Entity Layer, veritabanı nesnelerini içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Abstact
{
    // IEducationDal arayüzü, Education sınıfı için veritabanı erişim operasyonlarının tanımlandığı bir arayüzdür.
    public interface IEducationDal : IGenericDal<Education>
    {
        // IGenericDal arayüzünü implemente ederek, Education sınıfına özgü veritabanı erişim operasyonlarını içerir.
    }
}
