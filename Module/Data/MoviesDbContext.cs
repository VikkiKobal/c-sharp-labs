using Microsoft.EntityFrameworkCore;
using MovieDatabase.Models; 

namespace MovieDatabase.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-T94V6UV\SQLEXPRESS;Database=MoviesDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
