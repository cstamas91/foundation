using CST.Demo.Data.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace CST.Demo.Data
{
    public partial class DemoContext
    {
        public DbSet<User> Users { get; set; }

        protected void OnIdentityCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
