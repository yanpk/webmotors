using System;
using System.Threading.Tasks;

namespace WebMotors.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        int Commit();
        Task<int> CommitAsync();
    }
}
