using Microsoft.EntityFrameworkCore;

namespace EFDALClassLibrary
{
    public class EmployeeDBContext : DbContext
    {
        // Configure/MAP Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EmpManagementDB;Integrated Security=True");

            //.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }


        // Configure/MAP Tables - map entity class with tables
        // Map Employee class to Employees Table
        public DbSet<Employee> Employees { get; set; }

    }
}
