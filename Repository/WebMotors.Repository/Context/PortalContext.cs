using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebMotors.Repository.Context
{
    public partial class PortalContext : DbContext
    {
        private readonly IConfiguration _config;

        public bool IsDisposed = false;

        public PortalContext(IConfiguration config) : base()
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=wLeads;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=wsi-dev.database.windows.net;Database=wLeads-dev;User Id=wsi;Password=Xotu2018;");
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }

        public override int SaveChanges()
        {
            ManageLogInformation();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ManageLogInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            ManageLogInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ManageLogInformation();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void ManageLogInformation()
        {
            ManageCreateDate();
            ManageUpdateDate();
            ManageSoftDeleteInsert();
        }

        private void ManageSoftDeleteInsert()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("IsActive") != null && entry.State == EntityState.Added))
            {
                entry.Property("IsActive").CurrentValue = true;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            IsDisposed = true;
        }

        private void ManageCreateDate()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateDate").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreateDate").IsModified = false;
                }
            }
        }

        private void ManageUpdateDate()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdateDate") != null && (entry.State == EntityState.Added || entry.State == EntityState.Modified)))
            {
                entry.Property("UpdateDate").CurrentValue = DateTime.Now;
            }
        }
    }
}
