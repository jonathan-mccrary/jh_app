using System.Text.Json.Serialization;
using jh_app.Domain.Contracts;

namespace jh_app.Domain.Models
{
    public class TweetData : ITweetData
    {
        [JsonPropertyName("data")]
        public Tweet Tweet { get; set; }
    }
}

