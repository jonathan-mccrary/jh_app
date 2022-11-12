using System.Text.Json.Serialization;
using jh_app.Domain.Contracts.Models.Twitter;

namespace jh_app.Domain.Models.Twitter
{
    public class TweetData : ITweetData
    {
        [JsonPropertyName("data")]
        public Tweet Tweet { get; set; }
    }
}

