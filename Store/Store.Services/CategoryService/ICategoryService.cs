using Store.Entities;
using Store.Models;

namespace Store.Services.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetAll();
        CategoryModel Add(CategoryModel categoryModel);
        CategoryModel GetCategory(int id);
        CategoryModel Update(CategoryModel categoryModel);
        bool Delete(int id);


        bool CheckIfExists(int id);
    }
}
