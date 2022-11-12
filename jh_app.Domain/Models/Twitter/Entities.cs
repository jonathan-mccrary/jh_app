using System.Text.Json.Serialization;
using jh_app.Domain.Contracts.Models.Twitter;

namespace jh_app.Domain.Models.Twitter
{
    public class Entities : IEntities
    {
        [JsonPropertyName("annotations")]
        public Annotation[] Annotations { get; set; }

        [JsonPropertyName("cashtags")]
        public Cashtag[] Cashtags { get; set; }

        [JsonPropertyName("hashtags")]
        public Hashtag[] Hashtags { get; set; }

        [JsonPropertyName("mentions")]
        public Mention[] Mentions { get; set; }

        [JsonPropertyName("urls")]
        public Url[] Urls { get; set; }

    }
}