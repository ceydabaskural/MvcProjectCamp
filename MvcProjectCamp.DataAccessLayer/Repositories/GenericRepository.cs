using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IRepositoryDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object; // T değerine karşılık gelen sınıfımızı tutar

        public GenericRepository()
        {
            _object = c.Set<T>();//object değerine contexte bağlı olarak gönderilen T değerini atıyoruz
        }

        public void Delete(T p)
        {
            var deleteEntity = c.Entry(p);
            deleteEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.FirstOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addEntity = c.Entry(p);
            addEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updateEntity = c.Entry(p);
            updateEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
