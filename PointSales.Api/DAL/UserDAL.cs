using Dapper;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Jcvalera.Core.DAL
{
    public class UserDAL : IUserDAL
    {
        public IConfiguration Configuration;
        public string ConnectionString = string.Empty;

        public UserDAL(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DbAppPointSales");
        }

        public async Task SaveUser(User user)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@username", user.Username, DbType.String);
                    parameters.Add("@password", user.Password, DbType.String);
                    parameters.Add("@profile", user.Profile, DbType.String);

                    await connection.ExecuteAsync("sp_SaveUser", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUser(User user)
        {
            var getUser = new User();

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@username", user.Username, DbType.String);
                    parameters.Add("@password", user.Password, DbType.String);

                    getUser = await connection.QueryFirstOrDefaultAsync<User>("sp_GetUser", parameters, commandType: CommandType.StoredProcedure);
                }

                return getUser;
            }
            catch (Exception ex)
            {
                 
                throw;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var lstCategories = new List<User>();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    lstCategories = connection.Query<User>("sp_GetUsers", commandType: CommandType.StoredProcedure).ToList();
                }

                return lstCategories;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idUser", user.IdUser, DbType.Int32);
                    parameters.Add("@username", user.Username, DbType.String);  
                    parameters.Add("@password", user.Password, DbType.String);
                    parameters.Add("@profile", user.Profile, DbType.String);

                    await connection.ExecuteAsync("sp_UpdateUser", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteUser(int idUser)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idUser", idUser, DbType.Int32);

                    await connection.ExecuteAsync("sp_DeleteUser", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
