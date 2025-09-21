using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.Extensions.Configuration;

namespace Jcvalera.Core.BLL
{
    public class BuyBLL : IBuyBLL
    {
        public IConfiguration Configuration;

        public IBuyDAL BuyDAL;

        public BuyBLL(IConfiguration configuration)
        {
            BuyDAL = new BuyDAL(configuration);
        }

        public async Task SaveBuy(Buy buy)
        {
            try
            {
                await BuyDAL.SaveBuy(buy);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Buy> GetBuy(int idBuy)
        {
            try
            {
                var buy = new Buy();

                buy = await BuyDAL.GetBuy(idBuy);

                return buy;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Buy>> GetAllBuys()
        {
            try
            {
                var lstBuys = new List<Buy>();

                lstBuys = await BuyDAL.GetAllBuys();

                return lstBuys;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateBuy(Buy buy)
        {
            try
            {
                await BuyDAL.UpdateBuy(buy);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteBuy(int idBuy)
        {
            try
            {
                await BuyDAL.DeleteBuy(idBuy);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
