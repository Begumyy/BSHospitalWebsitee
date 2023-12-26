using BSHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : BaseModel
    {

        // Listeleme Kısmı 
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);

        //Ekleme Kısmı
        void Add(T entity);

        void Delete(T entity);

        void DeleteById(int id);

        void AcceptById(int id);

        void DeclineById(int id);

        void Update(T entity);

        //DB set'e bağlanıyor ve ID çekim işlemi yapıyor 
        T GetById(int id);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        
    }
}
     


