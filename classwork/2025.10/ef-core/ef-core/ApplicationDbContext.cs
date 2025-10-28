using Microsoft.EntityFrameworkCore;

namespace ef_core {
    internal class ApplicationDbContext : DbContext {
        public ApplicationDbContext() => Database.EnsureCreated();

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }
    }
}
