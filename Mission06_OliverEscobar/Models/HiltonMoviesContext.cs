using Microsoft.EntityFrameworkCore;

namespace Mission06_OliverEscobar.Models
{
    public class HiltonMoviesContext : DbContext
    {
        public HiltonMoviesContext(DbContextOptions<HiltonMoviesContext> options) : base (options) //constructor
        { 
        }

        public DbSet<Application> Application { get; set; }
    }
}
