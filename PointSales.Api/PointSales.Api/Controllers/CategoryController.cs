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
    public class CategoryController : ControllerBase
    {
        public IConfiguration Configuration;

        public ICategoryBLL CategoryBLL;

        public CategoryController(IConfiguration configuration, ICategoryBLL categoryBLL)
        {
            Configuration = configuration;
            CategoryBLL = categoryBLL;
        }

        [HttpPost("saveCategory")]
        public async Task<IActionResult> SaveCategory([FromBody] Category category)
        {
            try
            {
                await CategoryBLL.SaveCategory(category);

                var response = new ApiResponse<string>(200, "La categoria se almaceno correctamnete.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getCategoryById/{idCategory}")]
        public async Task<IActionResult> GetCategoryById(int idCategory)
        {
            try
            {
                ApiResponse<Category> response;

                var category = await CategoryBLL.GetCategory(idCategory);

                response = new ApiResponse<Category>(category, (category == null ? 404 : 200), (category == null ? "Categoria no encontrada" : "Categoria obtenida correctamente."));

                return Ok(response);

            }
            catch (Exception ex)

            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getCategories")]
        public async Task<IActionResult> GetCategories()
        {

            try
            {
                var lstCategories = await CategoryBLL.GetAllCategories();
                
                var response = new ApiResponse<List<Category>>(lstCategories, (lstCategories.Count == 0 ? 404 : 200), (lstCategories.Count == 0 ? "No se encontraton categoria registradas" : "Categorías obtenidas correctamente"));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpPatch("updateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            try
            {
                await CategoryBLL.UpdateCategory(category);

                var response = new ApiResponse<string>(200, "La Categoria se actualizo correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpDelete("deleteCategory/{idCategory}")]
        public async Task<IActionResult> DeleteCategory(int idCategory)
        {
            try
            {
                await CategoryBLL.DeleteCategory(idCategory);

                var response = new ApiResponse<string>( 200, "La Categoria se elimino correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

    }
}
