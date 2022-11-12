using System.Text.Json.Serialization;
using jh_app.Domain.Contracts.Models.Twitter;

namespace jh_app.Domain.Models.Twitter
{
    public class Annotation : IAnnotation
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("probability")]
        public decimal Probability { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("normalized_text")]
        public string NormalizedText { get; set; }
    }
}