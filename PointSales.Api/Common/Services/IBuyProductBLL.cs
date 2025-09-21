using Jcvalera.Core.Common.Entities;

namespace Jcvalera.Core.Common.Services
{
    public interface IBuyProductBLL
    {
        Task SaveBuyProduct(BuyProduct buyProduct);

        Task<BuyProduct> GetBuyProduct(int idBuyProduct); //By id

        Task<List<BuyProduct>> GetAllBuyProducts();

        Task UpdateBuyProduct(BuyProduct buyProduct);

        Task DeleteBuyProduct(int idBuyProduct);
    }
}
