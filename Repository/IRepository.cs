using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ElmirProje.Models;

namespace ElmirProje.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetFindAsync(int id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Remove(int id);
        IQueryable GetQueryable();
    }
}
