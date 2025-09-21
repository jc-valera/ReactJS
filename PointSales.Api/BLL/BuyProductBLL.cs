using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.Extensions.Configuration;

namespace Jcvalera.Core.BLL
{
    public class BuyProductBLL : IBuyProductBLL
    {
        public IConfiguration Configuration;

        public IBuyProductDAL BuyProductDAL;

        public BuyProductBLL(IConfiguration configuration)
        {
            BuyProductDAL = new BuyProductDAL(configuration);
        }

        public async Task SaveBuyProduct(BuyProduct buy)
        {
            try
            {
                await BuyProductDAL.SaveBuyProduct(buy);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BuyProduct> GetBuyProduct(int idBuyProduct)
        {
            try
            {
                var buyProduct = new BuyProduct();

                buyProduct = await BuyProductDAL.GetBuyProduct(idBuyProduct);

                return buyProduct;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BuyProduct>> GetAllBuyProducts()
        {
            try
            {
                var lstBuysProduct = new List<BuyProduct>();

                lstBuysProduct = await BuyProductDAL.GetAllBuyProducts();

                return lstBuysProduct;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateBuyProduct(BuyProduct buyProduct)
        {
            try
            {
                await BuyProductDAL.UpdateBuyProduct(buyProduct);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteBuyProduct(int idBuyProduct)
        {
            try
            {
                await BuyProductDAL.DeleteBuyProduct(idBuyProduct);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
