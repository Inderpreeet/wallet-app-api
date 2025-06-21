using Microsoft.AspNetCore.Authorization;
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
        // ✅ In-memory user list
        private static List<LoginDto> _users = new();

        // ✅ Register new users
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] LoginDto dto)
        {
            if (_users.Any(u => u.Username == dto.Username))
            {
                return BadRequest("Username already exists.");
            }

            _users.Add(dto);
            return Ok("User registered successfully.");
        }

        // ✅ Login and return JWT token
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _users.FirstOrDefault(u => 
                u.Username == dto.Username && u.Password == dto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

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
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

