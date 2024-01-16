using EP.DAL.Abstact;    // Veritabanı erişim katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.DAL.Concrete;    // Veritabanı erişim katmanındaki somut (concrete) sınıfları içeren namespace
using EP.DAL.Repository;  // Genel (generic) bir repository sınıfını içeren namespace
using EP.EL;              // Entity Layer, veritabanı nesnelerini içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.EntityFramework
{
    // EfEducationUserDal sınıfı, EducationUser nesnesi için Entity Framework tabanlı veritabanı erişim operasyonlarını sağlayan bir sınıftır.
    public class EfEducationUserDal : GenericRepository<EducationUser>, IEducationUserDal
    {
        // Constructor: EfEducationUserDal sınıfının bir örneği oluşturulduğunda, GenericRepository sınıfının bir örneğini alır.
        public EfEducationUserDal(Context context) : base(context)
        {
            // GenericRepository sınıfının constructor'ına context parametresi geçilir.
        }
    }
}
