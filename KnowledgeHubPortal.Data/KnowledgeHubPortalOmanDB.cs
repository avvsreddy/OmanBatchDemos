using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.Data
{
    internal class KnowledgeHubPortalOmanDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=KnowledgeHubPortalOmanDB;Integrated Security=True");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }

    }
}
