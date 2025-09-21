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
    public class BuyController : ControllerBase
    {
        public IConfiguration Configuration;

        public IBuyBLL BuyBLL;

        public BuyController(IConfiguration configuration, IBuyBLL buyBLL)
        {
            Configuration = configuration;
            BuyBLL = buyBLL;
        }

        [HttpPost("saveBuy")]
        public async Task<IActionResult> SaveBuy([FromBody] Buy buy)
        {
            try
            {
                await BuyBLL.SaveBuy(buy);

                var response = new ApiResponse<string>(200, "La compra se almaceno correctamnete.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getBuyById/{idBuy}")]
        public async Task<IActionResult> GetBuyById(int idBuy)
        {
            try
            {
                ApiResponse<Buy> response;

                var buy = await BuyBLL.GetBuy(idBuy);

                response = new ApiResponse<Buy>(buy, (buy == null ? 404 : 200), (buy == null ? "Compra no encontrada" : "Compra obtenida correctamente."));

                return Ok(response);

            }
            catch (Exception ex)

            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getBuys")]
        public async Task<IActionResult> GetBuys()
        {

            try
            {
                var lstBuys = await BuyBLL.GetAllBuys();

                var response = new ApiResponse<List<Buy>>(lstBuys, (lstBuys.Count == 0 ? 404 : 200), (lstBuys.Count == 0 ? "No se encontraton compras registradas" : "Compras obtenidas correctamente"));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpPatch("updateBuy")]
        public async Task<IActionResult> UpdateBuy([FromBody] Buy buy)
        {
            try
            {
                await BuyBLL.UpdateBuy(buy);

                var response = new ApiResponse<string>(200, "La compra se actualizo correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpDelete("deleteBuy/{idBuy}")]
        public async Task<IActionResult> DeleteBuy(int idBuy)
        {
            try
            {
                await BuyBLL.DeleteBuy(idBuy);

                var response = new ApiResponse<string>(200, "La compra se elimino correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }
    }
}
