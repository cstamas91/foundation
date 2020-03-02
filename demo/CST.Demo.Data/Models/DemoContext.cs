
using CST.Common.Utils.Common.Data;
using CST.Demo.Data.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace CST.Demo.Data
{
    public class DemoContext : DbContext, ISelfFactory<DemoContext>
    {
        const string SCHEMA = "identity";
        public DemoContext Create(DbContextOptions<DemoContext> options)
        {
            return new DemoContext(options);
        }

        public DemoContext()
        {

        }

        public DemoContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(SCHEMA);
        }

        public DbSet<User> Users { get; set; }
    }
}