using System.Collections.ObjectModel;
using MarketPulse.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MarketPulse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentsController(IOptions<ApiSettings> options, IHttpClientFactory httpClientFactory, ILogger<InstrumentsController> logger) : ControllerBase
    {
        private readonly ApiSettings _options = options.Value;
        readonly HttpClient client = httpClientFactory.CreateClient();
        readonly ILogger<InstrumentsController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> GetAllInstruments()
        {
            string[] stockSymbols = {
                "AAPL", "MSFT", "GOOGL", "AMZN", "NVDA", "META", "TSLA", "BRK.B", "V", "UNH",
                "JNJ", "WMT", "JPM", "XOM", "PG", "MA", "AVGO", "ORCL", "HD", "CVX",
                "COST", "LLY", "ABBV", "MRK", "BAC", "PEP", "KO", "ADBE", "CSCO", "AMD",
                "CMCSA", "TMO", "CRM", "NFLX", "QCOM", "TXN", "INTC", "AMGN", "HON", "DIS",
                "INTU", "SBUX", "MDLZ", "PFE", "CAT", "GILD", "SPGI", "GE", "ISRG", "BKNG"
            };

            return Ok(stockSymbols);
        }

        [HttpGet("symbol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]

        public async Task<IActionResult> Symbol([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query should not be empty");
            }

            try
            {
                string escapedQuery = Uri.EscapeDataString(query);
                var response = await client.GetFromJsonAsync<TwelveDataResponse>($"{_options.TwelveDataBaseUrl}/quote?symbol={escapedQuery}&apikey={_options.TwelveDataApiKey}");
                return Ok(response);
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "Operation was cancelled by user.");
                return Problem(statusCode: StatusCodes.Status499ClientClosedRequest, title: "Upstream temporarily unavailable");
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == null)
                {
                    _logger.LogError(ex, "Upstream request failed without a HTTP status code.");
                    return Problem(statusCode: StatusCodes.Status503ServiceUnavailable, title: "Upstream did not respond");
                }
                if ((int)ex.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    _logger.LogError(ex, "Configuration problem.");
                    return Problem(statusCode: 500, title: "Service unavailable.");

                }
                if ((int)ex.StatusCode == StatusCodes.Status429TooManyRequests)
                {
                    _logger.LogError(ex, "Too many requests.");
                    return Problem(statusCode: 503, title: "Service temporarily unavailable.");
                }
                return Problem(statusCode: 503, title: "Unknown upstream failure.");
            }
        }
    }
}