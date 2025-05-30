using Microsoft.EntityFrameworkCore;
using SampleTask.Model;

namespace SampleTask.Data
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<EmployeeData> employess { get; set; }
    }
}
