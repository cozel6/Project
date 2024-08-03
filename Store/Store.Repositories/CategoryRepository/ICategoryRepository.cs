using Store.Entities;

namespace Store.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Add(Category category);
        Category GetCategory(int id);
        Category Update(Category category);
        bool Delete(Category category);

        bool CheckIfExists(int id);
        bool IsDuplicateCategoryName(string categoryName);
        Category GetCategoryWithProducts(int id);
    }
}
