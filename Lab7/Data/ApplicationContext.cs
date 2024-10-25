using Microsoft.EntityFrameworkCore;
using lab_5.Models;

namespace lab_5.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Bonus> Bonus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToTable("Employee"); 

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18, 2)"); 

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Bonus)
                .WithOne(b => b.Employee)
                .HasForeignKey(b => b.WorkerCode); 

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}
