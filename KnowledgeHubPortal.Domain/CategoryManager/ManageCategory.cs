using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;

namespace KnowledgeHubPortal.Domain.CategoryManager
{
    public class ManageCategory : IManageCategory
    {

        private ICategoryRepository repo;// = new CategoryRepository();

        // use some IoC to inject the dependancy object
        public ManageCategory(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public void CreateCategory(Category category)
        {
            // add any business rules here
            repo.CreateCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return repo.GetAllCategories();
        }

        public Category GetCategory(int id)
        {
            return repo.GetCategory(id);
        }

        public void UpdateCategory(Category category)
        {
            repo.UpdateCategory(category);
        }
    }
}
