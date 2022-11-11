using System;
using System.Text.Json.Serialization;
using jh_app.Domain.Contracts;

namespace jh_app.Domain.Models
{
    public class Mention : IMention
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}