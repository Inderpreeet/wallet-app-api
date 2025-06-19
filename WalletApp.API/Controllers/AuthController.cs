using Microsoft.AspNetCore.Mvc;

namespace WalletApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("API is working ✅");
    }
}

