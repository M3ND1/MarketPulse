using Microsoft.AspNetCore.Mvc;

namespace MarketPulse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController() : ControllerBase
    {

        [HttpGet("whoami")]
        public IActionResult WhoAmI()
        {
            return Ok("WillBeFetchedFromBearer");
        }
    }
}