
using MarketPulse.Domain;
using Microsoft.Extensions.Options;

namespace MarketPulse.Application
{
    public class TwelveDataService(IOptions<ApiSettings> apiSettings) : ITwelveDataService
    {
        private readonly ApiSettings _apiSettings = apiSettings.Value;

        public string GetApiBaseUrl() => _apiSettings.TwelveDataBaseUrl!;

        public string GetApiKey() => _apiSettings.TwelveDataApiKey!;
    }
}