using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Model;

namespace WebMotors.Interface
{
    public interface IAnuncioWebMotorsRepository : IGenericRepository<AnuncioWebMotors, int>
    {
        new IEnumerable<AnuncioWebMotors> GetAll(
            int page = 1,
            int pageSize = 10,
            string textSearch = "",
            string orderBy = "Id",
            bool ascending = true);

        new Task<IEnumerable<AnuncioWebMotors>> GetAllAsync(
            int page = 1,
            int pageSize = 10,
            string textSearch = "",
            string orderBy = "Id",
            bool ascending = true);

        new int Count(string textSearch);

        new Task<int> CountAsync(string textSearch);

    }
}
