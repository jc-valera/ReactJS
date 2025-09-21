using Jcvalera.Core.Common.Entities;

namespace Jcvalera.Core.Common.Services
{
    public interface ICategoryDAL
    {
        Task SaveCategory(Category categoru);

        Task<Category> GetCategory(int idCategory); //By id

        Task<List<Category>> GetAllCategories();

        Task UpdateCategory(Category category);

        Task DeleteCategory(int idCategory);
    }
}
