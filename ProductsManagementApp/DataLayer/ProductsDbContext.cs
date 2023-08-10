using Microsoft.EntityFrameworkCore;

namespace ProductsManagementApp.DataLayer
{
    public class ProductsDbContext : DbContext
    {
        // config the db server

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProductsDBOman;Integrated Security=True;MultipleActiveResultSets=True").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();
        }

        // config/map the tables

        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
