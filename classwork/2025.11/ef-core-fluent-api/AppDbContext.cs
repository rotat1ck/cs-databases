using Microsoft.EntityFrameworkCore;

namespace ef_core_fluent_api {
    internal class AppDbContext : DbContext {
        public DbSet<User> Users { get; set; }

        public AppDbContext() {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=db.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //modelBuilder.Ignore<Country>();
            //modelBuilder.Entity<User>().Ignore(u => u.Company);

            //modelBuilder.Entity<User>().Property("Id").HasField("user_id");
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_Id");

            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(30);

            modelBuilder.Entity<User>().HasData(
                new User {
                    Phonenumber = "71234567890"
                }
            );
        }
    }
}
