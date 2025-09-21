using Jcvalera.Core.Common.Api;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PointSales.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IConfiguration Configuration;

        public IProductBLL ProductBLL;

        public ProductController(IConfiguration configuration, IProductBLL productBLL)
        {
            Configuration = configuration;
            ProductBLL = productBLL;
        }

        [HttpPost("saveProduct")]
        public async Task<IActionResult> SaveProduct([FromBody] Product product)
        {
            try
            {
                await ProductBLL.SaveProduct(product);

                var response = new ApiResponse<string>(200, "El producto se almaceno correctamnete.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getProductById/{idProduct}")]
        public async Task<IActionResult> GetProductById(int idProduct)
        {
            try
            {
                ApiResponse<Product> response;

                var Product = await ProductBLL.GetProduct(idProduct);

                response = new ApiResponse<Product>(Product, (Product == null ? 404 : 200), (Product == null ? "Producto no encontrada" : "Producto obtenido correctamente."));

                return Ok(response);

            }
            catch (Exception ex)

            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProducts()
        {

            try
            {
                var lstProducts = await ProductBLL.GetAllProducts();

                var response = new ApiResponse<List<Product>>(lstProducts, (lstProducts.Count == 0 ? 404 : 200), (lstProducts.Count == 0 ? "No se encontraton productos registrados" : "Productos obtenidos correctamente"));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpPatch("updateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                await ProductBLL.UpdateProduct(product);

                var response = new ApiResponse<string>(200, "El producto se actualizo correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpDelete("deleteProduct/{idProduct}")]
        public async Task<IActionResult> DeleteProduct(int idProduct)
        {
            try
            {
                await ProductBLL.DeleteProduct(idProduct);

                var response = new ApiResponse<string>(200, "El producto se elimino correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getProductByIdCategory/{idCategory}")]
        public async Task<IActionResult> GetProductByIdCategory(int idCategory)
        {
            try
            {
                var lstProducts = await ProductBLL.GetProductByIdCategory(idCategory);

                var response = new ApiResponse<List<Product>>(lstProducts, (lstProducts.Count == 0 ? 404 : 200), (lstProducts.Count == 0 ? "No se encontraton productos registrados" : "Productos obtenidos correctamente"));

                return Ok(response);

            }
            catch (Exception ex)

            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }
    }
}
