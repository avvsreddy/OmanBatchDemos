using EmployeeService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Models.Data
{
    public class EmployeeDbContext : DbContext
    {
        // configure db server
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }


        // confiture tables
        public DbSet<Employee> Employees { get; set; }
    }
}
