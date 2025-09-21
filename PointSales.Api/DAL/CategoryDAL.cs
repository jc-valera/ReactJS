using Dapper;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Jcvalera.Core.DAL
{
    public class CategoryDAL : ICategoryDAL
    {

        public IConfiguration Configuration;

        public string ConnectionString = string.Empty;

        public CategoryDAL(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DbAppPointSales");
        }

        public async Task SaveCategory(Category category)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@nameCategory", category.NameCategory, DbType.String);

                    await connection.ExecuteAsync("sp_SaveCategory", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Category> GetCategory(int idCategory)
        {
            try
            {
                var getCategory = new Category();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idCategory", idCategory, DbType.Int32);

                    getCategory = await connection.QueryFirstOrDefaultAsync<Category>("sp_GetCategory", parameters, commandType: CommandType.StoredProcedure);
                }

                return getCategory;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                var lstCategories = new List<Category>();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    lstCategories = connection.Query<Category>("sp_GetCategories", commandType: CommandType.StoredProcedure).ToList();
                }

                return lstCategories;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateCategory(Category category)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@IdCategory", category.IdCategory, DbType.Int32);
                    parameters.Add("@nameCategory", category.NameCategory, DbType.String);

                    await connection.ExecuteAsync("sp_UpdateCategory", parameters, commandType: CommandType.StoredProcedure);
                }   
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteCategory(int idCategory)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idCategory", idCategory, DbType.Int32);

                    await connection.ExecuteAsync("sp_DeleteCategory", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
