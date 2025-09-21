using Jcvalera.Core.Common.Entities;

namespace Jcvalera.Core.Common.Services
{
    public interface IBuyBLL
    {
        Task SaveBuy(Buy buy);

        Task<Buy> GetBuy(int idBuy); //By id

        Task<List<Buy>> GetAllBuys();

        Task UpdateBuy(Buy buy);

        Task DeleteBuy(int idBuy);
    }
}
