using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.MVCWebApplication.Models;

namespace EmployeeManagement.MVCWebApplication.Data
{
    public class EmployeeManagementMVCWebApplicationContext : DbContext
    {
        public EmployeeManagementMVCWebApplicationContext (DbContextOptions<EmployeeManagementMVCWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeManagement.MVCWebApplication.Models.Employee> Employee { get; set; } = default!;
    }
}
