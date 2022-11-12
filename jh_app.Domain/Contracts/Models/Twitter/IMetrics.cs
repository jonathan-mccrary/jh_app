using System.Text.Json.Serialization;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface IMetrics
    {
        long? ImpressionCount { get; set; }
        long? RetweetCount { get; set; }
        long? QuoteCount { get; set; }
        long? TotalRetweetCount { get; }
        long? LikeCount { get; set; }
        long? Reply_Count { get; set; }
        long? UrlLinkClicks { get; set; }
        long? UserProfileClicks { get; set; }
        long? ViewCount { get; set; }
        long? Playback0Count { get; set; }
        long? Playback25Count { get; set; }
        long? Playback50Count { get; set; }
        long? Playback75Count { get; set; }
        long? Playback100Count { get; set; }
    }
}