using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WalletApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            // Dummy check – replace with real DB lookup
            if (dto.Username == "admin" && dto.Password == "password")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, dto.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsYourSuperSecretKey123!"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "WalletApp",
                    audience: "WalletAppUsers",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized("Invalid credentials.");
        }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
