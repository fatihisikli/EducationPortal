using EP.DAL.Abstact;    // Veritabanı erişim katmanındaki arayüz (interface) tanımlarını içeren namespace
using EP.DAL.Concrete;    // Veritabanı erişim katmanındaki somut (concrete) sınıfları içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Repository
{
    // GenericRepository sınıfı, genel (generic) bir repository sınıfını temsil eder.
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;   // Veritabanı bağlantısı için Context sınıfı

        // Constructor: GenericRepository sınıfının bir örneği oluşturulduğunda, bir Context örneği alır.
        public GenericRepository(Context context)
        {
            _context = context;
        }

        // Veritabanına yeni bir varlık ekler.
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        // Belirli bir varlığı veritabanından siler.
        public void Delete(T entityt)
        {
            _context.Remove(entityt);
            _context.SaveChanges();
        }

        // Belirli bir varlığı ID'ye göre veritabanından getirir.
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        // Tüm varlıkları veritabanında listeleyen bir metot.
        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        // Var olan bir varlığı günceller.
        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
