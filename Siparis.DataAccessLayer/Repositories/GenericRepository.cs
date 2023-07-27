using Siparis.DataAccessLayer.Abstract;
using Siparis.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siparis.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
