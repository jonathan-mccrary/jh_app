using System.Text.Json.Serialization;
using jh_app.Domain.Contracts.Models.Twitter;

namespace jh_app.Domain.Models.Twitter
{
    public class Cashtag : ICashtag
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}