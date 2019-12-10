using Comcept.Legacy.Core.Entities.CMSClient;
using Microsoft.EntityFrameworkCore;

namespace Comcept.Legacy.Infrastructure.Data
{
    public class CMSClientContext : DbContext
    {
        public CMSClientContext(DbContextOptions<CMSClientContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasNoKey();
            modelBuilder.Entity<GLAccount>().HasNoKey();
            modelBuilder.Entity<Discrepancy>().HasNoKey();
        }
    }
}