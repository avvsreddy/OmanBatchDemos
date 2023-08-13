using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repository
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        Category GetCategory(int id);
        List<Category> GetAllCategories();
    }
}
