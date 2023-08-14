using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.CategoryManager
{
    public interface IManageCategory
    {
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        Category GetCategory(int id);
        List<Category> GetAllCategories();
        void DeleteCategory(int id);

    }
}
