using System.Xml;
using InTimeOutTime.Model;
using Microsoft.EntityFrameworkCore;
namespace InTimeOutTime.Data
{
    public class EmployeeInTimeOutTimeDbContext : DbContext
    {
        public EmployeeInTimeOutTimeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<EmployeeTimeSheet> employeeTimeSheets { get; set; }
    }
}
