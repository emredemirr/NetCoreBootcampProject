using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {

            // Oracle, SQL Server, Postgres, MongoDB simüle edildi.
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=2,ProductName="MSI", UnitPrice=35000, UnitsInStock=12},
                new Product{ProductId=2,CategoryId=2,ProductName="Monster", UnitPrice=29530, UnitsInStock=22},
                new Product{ProductId=3,CategoryId=2,ProductName="Excalibur", UnitPrice=42260, UnitsInStock=9},
                new Product{ProductId=4,CategoryId=1,ProductName="IPhone", UnitPrice=52000, UnitsInStock=25},
                new Product{ProductId=5,CategoryId=1,ProductName="Xiaomi", UnitPrice=12420, UnitsInStock=98},
                new Product{ProductId=6,CategoryId=3,ProductName="Canon", UnitPrice=98125, UnitsInStock=16}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}