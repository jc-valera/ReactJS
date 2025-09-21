using Dapper;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Jcvalera.Core.DAL
{
    public class CustomerDAL : ICustomerDAL
    {
        public IConfiguration Configuration;

        public string ConnectionString = string.Empty;

        public CustomerDAL(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DbAppPointSales");
        }

        public async Task SaveCustomer(Customer customer)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@name", customer.Name, DbType.String);

                    await connection.ExecuteAsync("sp_SaveCustomer", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<Customer> GetCustomer(int idCustomer)
        {
            try
            {
                var getCustomer = new Customer();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idCustomer", idCustomer, DbType.Int32);

                    getCustomer = await connection.QueryFirstOrDefaultAsync<Customer>("sp_GetCustomer", parameters, commandType: CommandType.StoredProcedure);
                }

                return getCustomer;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                var lstCustomers = new List<Customer>();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    lstCustomers = connection.Query<Customer>("sp_GetCustomers", commandType: CommandType.StoredProcedure).ToList();
                }

                return lstCustomers;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idCustomer", customer.IdCustomer, DbType.Int32);
                    parameters.Add("@name", customer.Name, DbType.String);

                    await connection.ExecuteAsync("sp_UpdateCustomer", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteCustomer(int idCustomer)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idCustomer", idCustomer, DbType.Int32);

                    await connection.ExecuteAsync("sp_DeleteCustomer", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
