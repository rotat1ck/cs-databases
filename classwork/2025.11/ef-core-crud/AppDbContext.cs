using Microsoft.EntityFrameworkCore;

namespace ef_core_crud {
    public class AppDbContext : DbContext {
        public DbSet<User> Users { get; set; }

        public AppDbContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=db.db");
        }
    }
}
