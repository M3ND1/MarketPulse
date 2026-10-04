// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.Text.Json.Serialization;
namespace MarketPulse.Domain
{
    public class FiftyTwoWeek
    {
        [JsonPropertyName("low")]
        public string Low { get; set; }

        [JsonPropertyName("high")]
        public string High { get; set; }

        [JsonPropertyName("low_change")]
        public string LowChange { get; set; }

        [JsonPropertyName("high_change")]
        public string HighChange { get; set; }

        [JsonPropertyName("low_change_percent")]
        public string LowChangePercent { get; set; }

        [JsonPropertyName("high_change_percent")]
        public string HighChangePercent { get; set; }

        [JsonPropertyName("range")]
        public string Range { get; set; }
    }

    public class TwelveDataResponse
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("mic_code")]
        public string MicCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("datetime")]
        public string Datetime { get; set; }

        [JsonPropertyName("timestamp")]
        public int? Timestamp { get; set; }

        [JsonPropertyName("last_quote_at")]
        public int? LastQuoteAt { get; set; }

        [JsonPropertyName("open")]
        public string Open { get; set; }

        [JsonPropertyName("high")]
        public string High { get; set; }

        [JsonPropertyName("low")]
        public string Low { get; set; }

        [JsonPropertyName("close")]
        public string Close { get; set; }

        [JsonPropertyName("volume")]
        public string Volume { get; set; }

        [JsonPropertyName("previous_close")]
        public string PreviousClose { get; set; }

        [JsonPropertyName("change")]
        public string Change { get; set; }

        [JsonPropertyName("percent_change")]
        public string PercentChange { get; set; }

        [JsonPropertyName("average_volume")]
        public string AverageVolume { get; set; }

        [JsonPropertyName("rolling_1d_change")]
        public string Rolling1dChange { get; set; }

        [JsonPropertyName("rolling_7d_change")]
        public string Rolling7dChange { get; set; }

        [JsonPropertyName("rolling_change")]
        public string RollingChange { get; set; }

        [JsonPropertyName("is_market_open")]
        public bool? IsMarketOpen { get; set; }

        [JsonPropertyName("fifty_two_week")]
        public FiftyTwoWeek FiftyTwoWeek { get; set; }

        [JsonPropertyName("extended_change")]
        public string ExtendedChange { get; set; }

        [JsonPropertyName("extended_percent_change")]
        public string ExtendedPercentChange { get; set; }

        [JsonPropertyName("extended_price")]
        public string ExtendedPrice { get; set; }

        [JsonPropertyName("extended_timestamp")]
        public int? ExtendedTimestamp { get; set; }
    }
}
