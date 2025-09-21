using Jcvalera.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.Common.Services
{
    public interface IBuyProductDAL
    {
        Task SaveBuyProduct(BuyProduct buyProduct);

        Task<BuyProduct> GetBuyProduct(int idBuyProduct); //By id

        Task<List<BuyProduct>> GetAllBuyProducts();

        Task UpdateBuyProduct(BuyProduct buyProduct);

        Task DeleteBuyProduct(int idBuyProduct);
    }
}
