using System;
using System.Text.Json.Serialization;
using jh_app.Domain.Contracts;

namespace jh_app.Domain.Models
{
    public class Hashtag : IHashtag
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}