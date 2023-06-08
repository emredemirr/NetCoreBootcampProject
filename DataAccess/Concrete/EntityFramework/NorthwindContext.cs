using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    /*
     *  Context Class : Veritabanı ve proje classlarını(entity) eşleştirme ve bağlamaya yarar.
    */
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
             * Server=(localdb)\MSSQLLocalDB --> Sunucu adını yada ip gir.
             * Database=Northwind;           --> Veritabanı adını yaz.
             * Trusted_Connection=true       --> Bağlantıda kullanıcı adı ve şifre sorma.
            */
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }


        /*
         * DbSet<Product> Products --> Product entity classını veritabanındaki Products tablosuna eşitle.
         * DbSet<Product>  --> Product Entity
         * Products        --> Veritabanı tablosu
        */
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
