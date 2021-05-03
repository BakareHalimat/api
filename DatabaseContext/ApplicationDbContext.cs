using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Authour> Authour { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}