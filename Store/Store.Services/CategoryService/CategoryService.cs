using AutoMapper;
using Store.Entities;
using Store.Models;
using Store.Repositories;

namespace Store.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            var categories = categoryRepository.GetAll();
            var categoryModels = mapper.Map<List<CategoryModel>>(categories);

            return categoryModels;
        }

        public CategoryModel Add(CategoryModel categoryModel)
        {
            //check if duplicate name
            // if yes, return null
            var categoryNameExists = categoryRepository.IsDuplicateCategoryName(categoryModel.CategoryName);

            if (categoryNameExists)//category name exista DEJA
            {
                return null;
            }

            //transformam din model->domain
            var categoryToAdd = mapper.Map<Category>(categoryModel);

            var newCategory = categoryRepository.Add(categoryToAdd);

            return mapper.Map<CategoryModel>(newCategory);
        }

        public CategoryModel GetCategory(int id)
        {
            var categoryById = categoryRepository.GetCategory(id);
            return mapper.Map<CategoryModel>(categoryById);
        }

        public CategoryModel? Update(CategoryModel categoryModel)
        {
            var existingItem = categoryRepository.GetCategory(categoryModel.Categoryid);

            if (existingItem == null)
            {
                return null;
            }

            var categoryToUpdate = mapper.Map(categoryModel, existingItem);

            var categoryFromDb = categoryRepository.Update(categoryToUpdate);
            return mapper.Map<CategoryModel>(categoryFromDb);
        }

        public bool Delete(int id)
        {
            var itemsToDelete = categoryRepository.GetCategoryWithProducts(id);

            if (itemsToDelete != null)
            {
                //don't delete items if they have products
                if (itemsToDelete.Products.Count > 0)
                {
                    return false;
                }
            }

            var deleted = categoryRepository.Delete(itemsToDelete);

            return deleted;
        }

        public bool CheckIfExists(int id)
        {
            return categoryRepository.CheckIfExists(id);
        }
    }
}
