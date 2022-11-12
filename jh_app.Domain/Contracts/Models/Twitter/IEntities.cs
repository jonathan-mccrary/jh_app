using System.Text.Json.Serialization;
using jh_app.Domain.Models.Twitter;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface IEntities
    {
        Annotation[] Annotations { get; set; }
        Cashtag[] Cashtags { get; set; }
        Hashtag[] Hashtags { get; set; }
        Mention[] Mentions { get; set; }
        Url[] Urls { get; set; }
    }
}