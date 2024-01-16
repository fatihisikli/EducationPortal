using EP.EL;                 // Entity Layer, veritabanı nesnelerini içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.BL.Abstract
{
    // IEducationUserServices arayüzü, EducationUser sınıfı için iş mantığı servislerinin tanımlandığı bir arayüzdür.
    public interface IEducationUserServices : IGenericServices<EducationUser>
    {
        // IGenericServices arayüzünü implemente ederek, EducationUser sınıfına özgü iş mantığı servislerini içerir.
    }
}
