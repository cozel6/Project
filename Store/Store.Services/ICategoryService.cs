using Store.Entities;
using Store.Models;

namespace Store.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetAll();
        Category Add(CategoryModel categoryModel);
        Category GetCategory(int id);
        Category Update(CategoryModel category);
        bool Delete(int id);

        bool CheckIfExists(int id);
    }
}
