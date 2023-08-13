using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;

namespace KnowledgeHubPortal.Data
{
    public class CategoryRepository : ICategoryRepository
    {

        private KnowledgeHubPortalOmanDB db = new KnowledgeHubPortalOmanDB();
        public void CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return db.Categories.Find(id);
        }

        public void UpdateCategory(Category category)
        {
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
