using Jcvalera.Core.Common.Api;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PointSales.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BuyProductController : ControllerBase
    {
        public IConfiguration Configuration;

        public IBuyProductBLL BuyProductBLL;

        public BuyProductController(IConfiguration configuration, IBuyProductBLL buyProductBLL)
        {
            Configuration = configuration;
            BuyProductBLL = buyProductBLL;
        }

        [HttpPost("saveBuyProduct")]
        public async Task<IActionResult> SaveBuyProduct([FromBody] BuyProduct buyProduct)
        {
            try
            {
                await BuyProductBLL.SaveBuyProduct(buyProduct);

                var response = new ApiResponse<string>(200, "La compra por producto se almaceno correctamnete.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getBuyProductById/{idBuyProduct}")]
        public async Task<IActionResult> GetBuyProductById(int idBuyProduct)
        {
            try
            {
                ApiResponse<BuyProduct> response;

                var BuyProduct = await BuyProductBLL.GetBuyProduct(idBuyProduct);

                response = new ApiResponse<BuyProduct>(BuyProduct, (BuyProduct == null ? 404 : 200), (BuyProduct == null ? "compra producto no encontrada" : "Compra producto obtenida correctamente."));

                return Ok(response);

            }
            catch (Exception ex)

            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getBuyProducts")]
        public async Task<IActionResult> GetBuyProducts()
        {

            try
            {
                var lstBuyProducts = await BuyProductBLL.GetAllBuyProducts();

                var response = new ApiResponse<List<BuyProduct>>(lstBuyProducts, (lstBuyProducts.Count == 0 ? 404 : 200), (lstBuyProducts.Count == 0 ? "No se encontraton compras por producto registradas" : "Compras por producto obtenidas correctamente"));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpPatch("updateBuyProduct")]
        public async Task<IActionResult> UpdateBuyProduct([FromBody] BuyProduct buyProduct)
        {
            try
            {
                await BuyProductBLL.UpdateBuyProduct(buyProduct);

                var response = new ApiResponse<string>(200, "La compra por producto se actualizo correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpDelete("deleteBuyProduct/{idBuyProduct}")]
        public async Task<IActionResult> DeleteBuyProduct(int idBuyProduct)
        {
            try
            {
                await BuyProductBLL.DeleteBuyProduct(idBuyProduct);

                var response = new ApiResponse<string>(200, "La compra por producto se elimino correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }
    }
}
