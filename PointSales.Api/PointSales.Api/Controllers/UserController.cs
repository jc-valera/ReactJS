using Jcvalera.Core.Common.Api;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PointSales.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration Configuration;

        public IUserBLL UserBLL;

        public UserController(IConfiguration configuration, IUserBLL userBLL)
        {
            Configuration = configuration;
            UserBLL = userBLL;
        }


        [HttpPost("saveUser")]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            try
            {
                await UserBLL.SaveUser(user);

                var response = new ApiResponse<string>(200, "El usuario se almaceno correctamnete.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }


        [HttpGet("getUser")]
        public async Task<IActionResult> GetUserById([FromBody] User user)
        {
            try
            {
                ApiResponse<Category> response;

                var getUser = await UserBLL.GetUser(user);

                response = new ApiResponse<Category>(getUser.Username, (getUser.Username == null ? 404 : 200), (getUser == null ? "Usuario no encontrado" : "Usuario obtenido correctamente."));

                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {

            try
            {
                var lstUsers = await UserBLL.GetAllUsers();
                
                var response = new ApiResponse<List<User>>(lstUsers, (lstUsers.Count == 0 ? 404 : 200), (lstUsers.Count == 0 ? "No se encontraton usuario registradas" : "Usuario obtenidos correctamente"));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }


        [HttpPatch("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                await UserBLL.UpdateUser(user);

                var response = new ApiResponse<string>(200, "El usuario se actualizo correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }

        [HttpDelete("deleteUser/{idUser}")]
        public async Task<IActionResult> DeleteUser(int idUser)
        {
            try
            {
                await UserBLL.DeleteUser(idUser);

                var response = new ApiResponse<string>( 200, "El usuario se elimino correctamente.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
        }
         
    }
}
