using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            /*
             * Context nesnesi biraz pahallı olduğu için işi bitince bellekten silinmesi gerekir.
             * Carbage collector belli aralıklarla işi biten nesneleri gelip siler ancak burada using'in farkı carbage collector'u kendisi çağırıp işim bitti nesneyi sil der.
             * Böylece işi biten nesneler bellekte boşuna yer kaplamaz.
             * Araştırmak istersen "IDispossable Pattern implementation of C#" diye arayabilirsin.
            */
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var addedEntity = northwindContext.Entry(entity); // Eklenecek nesnenin referansını yakala.
                addedEntity.State = EntityState.Added;           //  Bu nesnenin ekleneceğini belirt.
                northwindContext.SaveChanges();                 //   Değişikliği yap ve kaydet.
            }
        }

        public void Delete(Product entity)
        {
            /*
             * Context nesnesi biraz pahallı olduğu için işi bitince bellekten silinmesi gerekir.
             * Carbage collector belli aralıklarla işi biten nesneleri gelip siler ancak burada using'in farkı carbage collector'u kendisi çağırıp işim bitti nesneyi sil der.
             * Böylece işi biten nesneler bellekte boşuna yer kaplamaz.
             * Araştırmak istersen "IDispossable Pattern implementation of C#" diye arayabilirsin.
            */
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var deleteEntity = northwindContext.Entry(entity); // Silinecek nesnenin referansını yakala.
                deleteEntity.State = EntityState.Deleted;         //  Bu nesnenin silinmesi gerektiğini belirt.
                northwindContext.SaveChanges();                  //   Değişikliği yap ve kaydet.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return northwindContext.Set<Product>().SingleOrDefault(filter); // Filtreyi uygula ve nesneyi getir.
            }
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return filter == null
                    ? northwindContext.Set<Product>().ToList() // Filtre null ise bütün ürünleri liste halinde getir.
                    : northwindContext.Set<Product>().Where(filter).ToList(); // Filtreyi uygula ve dönen nesneleri liste halinde getir.
            }
        }
        public void Update(Product entity)
        {
            /*
             * Context nesnesi biraz pahallı olduğu için işi bitince bellekten silinmesi gerekir.
             * Carbage collector belli aralıklarla işi biten nesneleri gelip siler ancak burada using'in farkı carbage collector'u kendisi çağırıp işim bitti nesneyi sil der.
             * Böylece işi biten nesneler bellekte boşuna yer kaplamaz.
             * Araştırmak istersen "IDispossable Pattern implementation of C#" diye arayabilirsin.
            */
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var updatedEntity = northwindContext.Entry(entity); // Güncellenecek nesnenin referansını yakala.
                updatedEntity.State = EntityState.Modified;        //  Bu nesnenin güncellenmesi gerektiğini belirt.
                northwindContext.SaveChanges();                   //   Değişikliği yap ve kaydet.
            }
        }
    }
}
