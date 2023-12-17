using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Repository.Shared.Concrete
{
    public class Repository<T>:IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add (T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById (int id)
        {
            T entity = _dbSet.Find(id);
            entity.IsCanceled = true;
            _dbSet.Update(entity);
            
        }

        public void AcceptById(int id)
        {
            T entity = _dbSet.Find(id);
            entity.IsAccepted = true;
            _dbSet.Update(entity);

        }

        public IQueryable<T>GetAll()
        {
            return _dbSet.Where(x => x.IsCanceled==false);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return GetAll().Where(filter);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(d => d.IsCanceled == false).FirstOrDefault(filter);
        }

        public void Update(T entity)
        {
            
            _dbSet.Update(entity);
        }
    }
}
