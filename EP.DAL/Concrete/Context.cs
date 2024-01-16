using EP.EL;                             // Entity Layer, veritabanı nesnelerini içeren namespace
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // ASP.NET Core Identity özelliklerini içeren namespace
using Microsoft.EntityFrameworkCore;     // Entity Framework Core kütüphanesini içeren namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DAL.Concrete
{
    // Context sınıfı, Entity Framework Core tarafından kullanılan veritabanı bağlantı ve yapılandırma sınıfıdır.
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        // DbContextOptionsBuilder ile veritabanı bağlantı ayarları yapılır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı bağlantı dizesi ayarlanır (örnekte SQL Server kullanılmıştır).
            optionsBuilder.UseSqlServer("Server=FATIH;Database=EducationProjectCase11111;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        // DbSet, veritabanındaki tablolara karşılık gelen nesneleri içerir.
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationUser> EducationUsers { get; set; }
    }
}
