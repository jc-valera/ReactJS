using Jcvalera.Core.Common.Entities;

namespace Jcvalera.Core.Common.Services
{
    public interface IProductDAL
    {
        Task SaveProduct(Product product);

        Task<Product> GetProduct(int idProduct); //By id
        
        Task<List<Product>> GetAllProducts();

        Task UpdateProduct(Product Product);

        Task DeleteProduct(int idProduct);

        Task<List<Product>> GetProductByIdCategory(int idCategory);

    }
}
