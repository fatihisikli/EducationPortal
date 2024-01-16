using EP.EL;                 // Entity Layer, veritabanı nesnelerini içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Abstact
{
    // IEducationUserDal arayüzü, EducationUser sınıfı için veritabanı erişim operasyonlarının tanımlandığı bir arayüzdür.
    public interface IEducationUserDal : IGenericDal<EducationUser>
    {
        // IGenericDal arayüzünü implemente ederek, EducationUser sınıfına özgü veritabanı erişim operasyonlarını içerir.
    }
}
