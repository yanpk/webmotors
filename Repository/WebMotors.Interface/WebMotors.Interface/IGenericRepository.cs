using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Interface
{
    public interface IGenericRepository<T, TKey> : IDisposable where T : class
    {
        void Add(T obj);
        Task AddAsync(T obj);
        void Delete(T obj);
        void Delete(TKey id);
        void Update(T obj);
        T Get(TKey id);
        Task<T> GetAsync(TKey id);
        int Count();
        int Count(string textSearch);
        Task<int> CountAsync();
        Task<int> CountAsync(string textSearch);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(int page = 1, int pageSize = 10, string textSearch = "", string orderBy = "Id", bool ascending = true);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(int page = 1, int pageSize = 10, string textSearch = "", string orderBy = "Id", bool ascending = true);
    }
}
