using LeaveManagement.Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Infra.Data
{
    public class LeaveDbContext : DbContext
    {
        public LeaveDbContext(DbContextOptions<LeaveDbContext> options)
           : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasKey(x => x.Index);

            modelBuilder.Entity<Employee>()
             .HasOne<Department>(x => x.Department)
                .WithMany(g => g.Employees)
             .HasForeignKey(s => s.CurrentDepartmentId)
             .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
