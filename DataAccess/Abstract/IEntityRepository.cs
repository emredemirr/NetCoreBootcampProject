using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

    /*
     * Burada generic kısıtlama uygulandı (where T : class, IEntity, new())
     * T, sadece class olabilir. IEntity implemente eden bir nesne olabilir.
     * ve son olarak new'lenebilir olmalı yani interface gibi soyut nesneler olamaz.
     * Sonuç olarak T olarak sadece entity nesnesinin gönderilmesi için kısıtlama uygulamış olduk.
    */
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
