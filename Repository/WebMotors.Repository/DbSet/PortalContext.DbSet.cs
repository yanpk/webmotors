using Microsoft.EntityFrameworkCore;
using WebMotors.Model;
using WebMotors.Repository.Map;

namespace WebMotors.Repository.Context
{
    public partial class PortalContext : DbContext
    {
        #region dbo
        public DbSet<AnuncioWebMotors> AnuncioWebMotors { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region dbo
            modelBuilder.ApplyConfiguration<AnuncioWebMotors>(new AnuncioWebMotorsMap());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
