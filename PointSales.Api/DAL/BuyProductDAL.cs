using Dapper;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Jcvalera.Core.DAL
{
    public class BuyProductDAL : IBuyProductDAL
    {
        public IConfiguration Configuration;

        public string ConnectionString = string.Empty;

        public BuyProductDAL(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DbAppPointSales");
        }

        public async Task SaveBuyProduct(BuyProduct buyProduct)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    //parameters.Add("@idBuyProduct", buyProduct.IdBuyProduct, DbType.Int32);
                    parameters.Add("@idBuy", buyProduct.IdBuy, DbType.Int32);
                    parameters.Add("@idProduct", buyProduct.IdProduct, DbType.Int32);
                    parameters.Add("@quantity", buyProduct.Quantity, DbType.Int32);
                    parameters.Add("@price", buyProduct.Price, DbType.Decimal);

                    await connection.ExecuteAsync("sp_SaveBuyProduct", parameters, commandType: CommandType.StoredProcedure);
                }
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
                var getBuyProduct = new BuyProduct();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idBuyProduct", idBuyProduct, DbType.Int32);

                    getBuyProduct = await connection.QueryFirstOrDefaultAsync<BuyProduct>("sp_GetBuyProduct", parameters, commandType: CommandType.StoredProcedure);
                }

                return getBuyProduct;
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
                var lstBuyProducts = new List<BuyProduct>();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    lstBuyProducts = connection.Query<BuyProduct>("sp_GetBuyProducts", commandType: CommandType.StoredProcedure).ToList();
                }

                return lstBuyProducts;
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
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idBuyProduct", buyProduct.IdBuyProduct, DbType.Int32);
                    parameters.Add("@idBuy", buyProduct.IdBuy, DbType.Int32);
                    parameters.Add("@idProduct", buyProduct.IdProduct, DbType.Int32);
                    parameters.Add("@quantity", buyProduct.Quantity, DbType.Int32);
                    parameters.Add("@price", buyProduct.Price, DbType.Decimal);

                    await connection.ExecuteAsync("sp_UpdateBuyProduct", parameters, commandType: CommandType.StoredProcedure);
                }
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
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idBuyProduct", idBuyProduct, DbType.Int32);

                    await connection.ExecuteAsync("sp_DeleteBuyProduct", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
