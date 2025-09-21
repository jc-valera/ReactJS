using Jcvalera.Core.Common.Api;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PointSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public IConfiguration Configuration;
        public AppSettings AppSettings;
        public IUserBLL UserBLL;

        public AuthorizationController(IConfiguration configuration, IOptions<AppSettings> appSettings, IUserBLL userBLL)
        {
            Configuration = configuration;
            AppSettings = appSettings.Value;

            UserBLL = userBLL;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] User user)
        {
            try
            {
                var getUser = await UserBLL.GetUser(user);

                if (getUser != null)
                {
                    var keyBytes = Encoding.ASCII.GetBytes(AppSettings.SecretKey);

                    var claims = new ClaimsIdentity(
                        new Claim[]
                        {
                        new Claim(ClaimTypes.NameIdentifier, getUser.IdUser.ToString()),
                        new Claim(ClaimTypes.Email, getUser.Username),
                        new Claim(ClaimTypes.Role, getUser.Profile)
                        });

                    var tokenDescriptior = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(60),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptior);

                    var response = new ApiResponse<string>(tokenHandler.WriteToken(tokenConfig), 200, "Token generado correctamente.");

                    return Ok(response);
                }
                else
                {
                    return Unauthorized(new ApiResponse<string>(401, "Usuario o Contraseña incorrecta."));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "Error inesperado en el servidor", new[] { ex.Message }));
            }
            
        }
    }
}
