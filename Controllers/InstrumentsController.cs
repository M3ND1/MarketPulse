using MarketPulse.Application;
using MarketPulse.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

namespace MarketPulse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentController(IOptions<ApiSettings> options, IHttpClientFactory httpClientFactory) : ControllerBase
    {
        private ApiSettings _options = options.Value;
        HttpClient client = httpClientFactory.CreateClient();

        [HttpGet("apple")]
        public async Task<IActionResult> GetApple()
        {
            var something = await client.GetFromJsonAsync<TwelveDataResponse>($"{_options.TwelveDataBaseUrl}/quote?symbol=AAPL&apikey={_options.TwelveDataApiKey}");
            return Ok(something);            
        }
    }
}