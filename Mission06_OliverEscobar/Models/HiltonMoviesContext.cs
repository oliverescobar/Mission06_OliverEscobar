using Microsoft.EntityFrameworkCore;

namespace Mission06_OliverEscobar.Models
{
    public class HiltonMoviesContext : DbContext
    {
        public HiltonMoviesContext(DbContextOptions<HiltonMoviesContext> options) : base (options) //constructor
        { 
        }

        // public DbSet<Application> Application { get; set; }
        public DbSet<Application> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //seed data 
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "Adventure" },
                new Category { CategoryId = 3, CategoryName = "Documentary" },
                new Category { CategoryId = 4, CategoryName = "Fantasy" },
                new Category { CategoryId = 5, CategoryName = "Musical" },
                new Category { CategoryId = 6, CategoryName = "Space" }
                );
        }
    }
}
