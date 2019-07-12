using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Interface;
using WebMotors.Model;
using WebMotors.Repository.Context;

namespace WebMotors.Repository
{
    public class AnuncioWebMotorsRepository : GenericRepository<AnuncioWebMotors, int>, IAnuncioWebMotorsRepository
    {
        public AnuncioWebMotorsRepository(PortalContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<AnuncioWebMotors> GetAll(int page = 1, int pageSize = 10, string textSearch = "", string orderBy = "Id", bool ascending = true)
        {
            var query = Context.AnuncioWebMotors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(textSearch))
                query = query.Where(t => t.Marca.Contains(textSearch));

            if (ascending)
                query = query.OrderBy(t => t.GetType().GetProperty(orderBy) != null ? t.GetType().GetProperty(orderBy).GetValue(t) : t.GetType().GetProperty("Id").GetValue(t));
            else
                query = query.OrderByDescending(t => t.GetType().GetProperty(orderBy) != null ? t.GetType().GetProperty(orderBy).GetValue(t) : t.GetType().GetProperty("Id").GetValue(t));

            query = query.Skip(pageSize * (page - 1)).Take(pageSize);
            return query.AsEnumerable();
        }


        public override async Task<IEnumerable<AnuncioWebMotors>> GetAllAsync(int page = 1, int pageSize = 10, string textSearch = "", string orderBy = "Id", bool ascending = true)
        {
            var query = Context.AnuncioWebMotors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(textSearch))
                query = query.Where(t => t.Marca.Contains(textSearch));

            if (ascending)
                query = query.OrderBy(t => t.GetType().GetProperty(orderBy) != null ? t.GetType().GetProperty(orderBy).GetValue(t) : t.GetType().GetProperty("Id").GetValue(t));
            else
                query = query.OrderByDescending(t => t.GetType().GetProperty(orderBy) != null ? t.GetType().GetProperty(orderBy).GetValue(t) : t.GetType().GetProperty("Id").GetValue(t));

            query = query.Skip(pageSize * (page - 1)).Take(pageSize);
            return await query.ToListAsync();
        }


        public override int Count(string textSearch)
        {
            return Context.AnuncioWebMotors.Count(t => t.Marca.Contains(textSearch));
        }

        public override Task<int> CountAsync(string textSearch)
        {
            return Context.AnuncioWebMotors.CountAsync(t => t.Marca.Contains(textSearch));
        }
    }
}
