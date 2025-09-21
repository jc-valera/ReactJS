using Jcvalera.Core.Common.Entities;

namespace Jcvalera.Core.Common.Services
{
    public interface IProductBLL
    {
        Task SaveProduct(Product product);

        Task<Product> GetProduct(int idProduct); //By id

        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetProductByIdCategory(int idCategory);

        Task UpdateProduct(Product Product);

        Task DeleteProduct(int idProduct);
    }
}
