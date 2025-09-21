using Dapper;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.DAL
{
    public class ProductDAL : IProductDAL
    {
        public IConfiguration Configuration;

        public string ConnectionString = string.Empty;

        public ProductDAL(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DbAppPointSales");
        }

        public async Task SaveProduct(Product product)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@name", product.Name, DbType.String);
                    parameters.Add("@sku", product.Sku, DbType.String);
                    parameters.Add("@price", product.Price, DbType.Decimal);
                    parameters.Add("@stock", product.Stock, DbType.Int32);
                    parameters.Add("@image", product.Image, DbType.String);
                    parameters.Add("@idCategory", product.IdCategory, DbType.Int32);

                    await connection.ExecuteAsync("sp_SaveProduct", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Product> GetProduct(int idProduct)
        {
            try
            {
                var getProduct = new Product();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idProduct", idProduct, DbType.Int32);

                    getProduct = await connection.QueryFirstOrDefaultAsync<Product>("sp_GetProduct", parameters, commandType: CommandType.StoredProcedure);
                }

                return getProduct;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var lstProducts = new List<Product>();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    lstProducts = connection.Query<Product>("sp_GetProducts", commandType: CommandType.StoredProcedure).ToList();
                }

                return lstProducts;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idProduct", product.IdProduct, DbType.Int32);
                    parameters.Add("@name", product.Name, DbType.String);
                    parameters.Add("@sku", product.Sku, DbType.String);
                    parameters.Add("@price", product.Price, DbType.Decimal);
                    parameters.Add("@stock", product.Stock, DbType.Int32);
                    parameters.Add("@image", product.Image, DbType.String);
                    parameters.Add("@idCategory", product.IdCategory, DbType.Int32);

                    await connection.ExecuteAsync("sp_UpdateProduct", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteProduct(int idProduct)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idProduct", idProduct, DbType.Int32);

                    await connection.ExecuteAsync("sp_DeleteProduct", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetProductByIdCategory(int idCategory)
        {
            try
            {
                var lstProducts = new List<Product>();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@idCategory", idCategory, DbType.Int32);

                    lstProducts = connection.Query<Product>("sp_GetProductByIdCategory", parameters, commandType: CommandType.StoredProcedure).ToList();
                }

                return lstProducts;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
