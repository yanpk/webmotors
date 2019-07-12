using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Interface;
using WebMotors.Repository.Context;

namespace WebMotors.Repository
{
    public class GenericRepository<T, TKey> : IDisposable, IGenericRepository<T, TKey> where T : class//, IEntity<TKey>, new()
    {
        protected PortalContext Context { get; private set; }

        public GenericRepository(PortalContext dbContext)
        {
            Context = dbContext;
        }

        public virtual void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public virtual void Delete(T obj)
        {
            Context.Set<T>().Remove(obj);
        }

        public virtual void Delete(TKey id)
        {
            var obj = Get(id);
            Delete(obj);
        }

        public virtual void Update(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public virtual T Get(TKey id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetAsync(TKey id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(T obj)
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual void Dispose()
        {
            Context.Dispose();
            Context = null;
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll(int page = 1, int pageSize = 10, string textSearch = "", string orderBy = "Id", bool ascending = true)
        {
            if (ascending)
                return Context.Set<T>().OrderBy(t => t.GetType().GetProperty(orderBy) != null ? t.GetType().GetProperty(orderBy).GetValue(t) : t.GetType().GetProperty("Id").GetValue(t)).Skip((page - 1) * pageSize).Take(pageSize); //TODO:Make Orderable to paginate befor ToList
            else
                return Context.Set<T>().OrderByDescending(t => t.GetType().GetProperty(orderBy) != null ? t.GetType().GetProperty(orderBy).GetValue(t) : t.GetType().GetProperty("Id").GetValue(t)).Skip((page - 1) * pageSize).Take(pageSize); //TODO:Make Orderable to paginate befor ToList

        }

        public virtual async Task AddAsync(T obj)
        {
            await Context.Set<T>().AddAsync(obj);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(int page = 1, int pageSize = 10, string textSearch = "", string orderBy = "Id", bool ascending = true)
        {
            if (ascending)
                return await Context.Set<T>().OrderBy(t => t.GetType().GetProperty(orderBy) != null ? t.GetType().GetProperty(orderBy).GetValue(t) : t.GetType().GetProperty("Id").GetValue(t)).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            else
                return await Context.Set<T>().OrderByDescending(t => t.GetType().GetProperty(orderBy) != null ? t.GetType().GetProperty(orderBy).GetValue(t) : t.GetType().GetProperty("Id").GetValue(t)).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual int Count()
        {
            return Context.Set<T>().Count();
        }
        public virtual async Task<int> CountAsync()
        {
            return await Context.Set<T>().CountAsync();
        }

        public virtual int Count(string textSearch)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> CountAsync(string textSearch)
        {
            throw new NotImplementedException();
        }
    }
}
