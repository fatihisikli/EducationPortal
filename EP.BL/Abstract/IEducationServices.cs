using EP.EL;                 // Entity Layer, veritabanı nesnelerini içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.BL.Abstract
{
    // IEducationServices arayüzü, Education sınıfı için iş mantığı servislerinin tanımlandığı bir arayüzdür.
    public interface IEducationServices : IGenericServices<Education>
    {
        // IGenericServices arayüzünü implemente ederek, Education sınıfına özgü iş mantığı servislerini içerir.
    }
}
