using Microsoft.AspNetCore.Mvc;

namespace WalletApp.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to WalletApp API. Visit /swagger to test endpoints.");
        }
    }
}

