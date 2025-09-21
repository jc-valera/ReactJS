using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.BLL
{
    public class ProductBLL : IProductBLL
    {

        public IProductDAL ProductDAL;

        public ProductBLL(IConfiguration configuration)
        {
            ProductDAL = new ProductDAL(configuration);
        }

        public async Task SaveProduct(Product product)
        {
            try
            {
                await ProductDAL.SaveProduct(product);
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
                var product = new Product();

                product = await ProductDAL.GetProduct(idProduct);

                return product;
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
                var products = new List<Product>();

                products = await ProductDAL.GetAllProducts();

                return products;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateProduct(Product Product)
        {
            try
            {
                await ProductDAL.UpdateProduct(Product);
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
                await ProductDAL.DeleteProduct(idProduct);
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
                var products = new List<Product>();

                products = await ProductDAL.GetProductByIdCategory(idCategory);

                return products;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
