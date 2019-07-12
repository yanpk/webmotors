using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebMotors.AspNetContext.Model;

namespace WebMotors.AspNetContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _config;
        public static readonly string conn = @"Server=(LocalDB)\\MSSQLLocalDB;Database=teste_webmotors;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public ApplicationDbContext(IConfiguration config)
        {
            _config = config;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
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

        private void ManageCreateDate()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateDate").CurrentValue = DateTime.Now.ToUniversalTime();
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
                entry.Property("UpdateDate").CurrentValue = DateTime.Now.ToUniversalTime();
            }
        }
    }
}
