using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Entities;

namespace Store.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext storeContext;

        public CategoryRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return storeContext.Categories;
        }

        public Category Add(Category category)
        {
            var itemAdded = storeContext.Categories.Add(category);
            storeContext.SaveChanges();
            return itemAdded.Entity;
        }

        public Category GetCategory(int id)
        {
            return storeContext.Categories.Find(id);
        }

        public Category Update(Category category)
        {
            var updatedCategory = storeContext.Categories.Update(category);
            storeContext.SaveChanges();

            return updatedCategory.Entity;
        }

        public bool Delete(Category category)
        {
            var deleted = storeContext.Categories.Remove(category);
            var result = storeContext.SaveChanges() > 0;
            return result;
        }

        public bool CheckIfExists(int id)
        {
            return storeContext.Categories.Any(x => x.Categoryid == id);
        }

        public bool IsDuplicateCategoryName(string categoryName)
        {
            return storeContext.Categories.Where(x => x.Categoryname == categoryName).Any();
        }

        public Category GetCategoryWithProducts(int id)
        {
            return storeContext.Categories
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Categoryid == id);
        }
    }
}
