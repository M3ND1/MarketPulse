using Microsoft.AspNetCore.Mvc;
using MarketPulse.Application;

namespace MarketPulse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketController(ITwelveDataService twelveDataService) : ControllerBase
    {
        private readonly ITwelveDataService _twelveDataService = twelveDataService;

        [HttpGet("apikey")]
        public IActionResult GetApiKey()
        {
            return Ok(new
            {
                ApiKey = _twelveDataService.GetApiKey() != null,
                BaseUrl = _twelveDataService.GetApiBaseUrl()
            });
        }
    }
}