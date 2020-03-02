using Microsoft.EntityFrameworkCore;

namespace CST.Demo.Data
{
    public partial class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnIdentityCreating(modelBuilder);
            OnTicketingCreating(modelBuilder);
        }
    }
}