using System;
using System.Text.Json.Serialization;
using jh_app.Domain.Contracts;

namespace jh_app.Domain.Models
{
    public class Entities : IEntities 
    {
        [JsonPropertyName("hashtags")]
        public Hashtag[] Hashtags { get; set; }

        [JsonPropertyName("mentions")]
        public Mention[] Mentions { get; set; }
    }
}