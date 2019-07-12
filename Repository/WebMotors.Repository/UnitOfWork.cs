using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using WebMotors.Interface;
using WebMotors.Repository.Context;

namespace WebMotors.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public PortalContext _db;
        public IDbContextTransaction Transaction;

        public UnitOfWork(PortalContext context)
        {
            _db = context;
        }
        public void BeginTransaction()
        {
            if (_db == null)
                throw new System.Exception("NULL Context found!");

            Transaction = _db.Database.BeginTransaction();
        }

        public int Commit()
        {
            var commited = _db.SaveChanges();

            if (Transaction == null)
                throw new System.Exception("NULL Context found!");

            Transaction.Commit();

            return commited;
        }

        public Task<int> CommitAsync()
        {
            var commited = _db.SaveChangesAsync();

            if (Transaction == null)
                throw new System.Exception("NULL Context found!");

            Transaction.Commit();

            return commited;
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }
    }
}
