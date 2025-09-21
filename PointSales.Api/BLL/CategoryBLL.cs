using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.Extensions.Configuration;

namespace Jcvalera.Core.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        public IConfiguration Configuration;

        public ICategoryDAL CategoryDAL;

        public CategoryBLL(IConfiguration configuration)
        {
            CategoryDAL = new CategoryDAL(configuration);
        }

        public async Task SaveCategory(Category category)
        {
            try
            {
                await CategoryDAL.SaveCategory(category);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Category> GetCategory(int idCategory)
        {
            try
            {
                var category = new Category();

                category = await CategoryDAL.GetCategory(idCategory);

                return category;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                var categories = new List<Category>();

                categories = await CategoryDAL.GetAllCategories();

                return categories;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateCategory(Category category)
        {
            try
            {
                await CategoryDAL.UpdateCategory(category);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteCategory(int idCategory)
        {
            try
            {
                await CategoryDAL.DeleteCategory(idCategory);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
