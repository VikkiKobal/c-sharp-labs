using Microsoft.EntityFrameworkCore;
using ConsoleAppDBBasics.Models;

namespace ConsoleAppDBBasics.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-T94V6UV\SQLEXPRESS;Database=StudentsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
