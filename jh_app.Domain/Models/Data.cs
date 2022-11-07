using System.Text.Json.Serialization;

namespace jh_app.Domain.Models
{
    public class Data
    {
        [JsonPropertyName("data")]
        public Tweet Tweet { get; set; }
    }
}

