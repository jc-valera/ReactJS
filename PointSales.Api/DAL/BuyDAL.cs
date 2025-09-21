using Dapper;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Jcvalera.Core.DAL
{
    public class BuyDAL : IBuyDAL
    {
        public IConfiguration Configuration;

        public string ConnectionString = string.Empty;

        public BuyDAL(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DbAppPointSales");
        }

        public async Task SaveBuy(Buy buy)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    //parameters.Add("@idBuy", buy.IdBuy, DbType.Int32);
                    parameters.Add("@idCustomers", buy.IdCustomers, DbType.Int32);
                    parameters.Add("@idUser", buy.IdUser, DbType.Int32);
                    parameters.Add("@dateBuy", buy.DateBuy, DbType.DateTime);
                    parameters.Add("@total", buy.Total, DbType.Decimal);
                    
                    await connection.ExecuteAsync("sp_SaveBuy", parameters, commandType: CommandType.StoredProcedure);
                }
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
                var getBuy = new Buy();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idBuy", idBuy, DbType.Int32);

                    getBuy = await connection.QueryFirstOrDefaultAsync<Buy>("sp_GetBuy", parameters, commandType: CommandType.StoredProcedure);
                }

                return getBuy;
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

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    lstBuys = connection.Query<Buy>("sp_GetBuys", commandType: CommandType.StoredProcedure).ToList();
                }

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
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idBuy", buy.IdBuy, DbType.Int32);
                    parameters.Add("@idCustomers", buy.IdCustomers, DbType.Int32);
                    parameters.Add("@idUser", buy.IdUser, DbType.Int32);
                    parameters.Add("@dateBuy", buy.DateBuy, DbType.DateTime);
                    parameters.Add("@total", buy.Total, DbType.Decimal);

                    await connection.ExecuteAsync("sp_UpdateBuy", parameters, commandType: CommandType.StoredProcedure);
                }
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
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idBuy", idBuy, DbType.Int32);

                    await connection.ExecuteAsync("sp_DeleteBuy", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
