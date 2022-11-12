using System.Text.Json.Serialization;
using jh_app.Domain.Models;
using jh_app.Domain.Models.Twitter;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface ITweet
    {
        string Id { get; set; }
        string Text { get; set; }
        string[] EditHistoryTweetIds { get; set; }
        dynamic Attachments { get; set; }
        string AuthorId { get; set; }
        dynamic ContextAnnotations { get; set; }
        string ConversationId { get; set; }
        DateTime CreatedAt { get; set; }
        EditControls EditControls { get; set; }
        Entities Entities { get; set; }
        string InReplyToUserId { get; set; }
        string Language { get; set; }
        Metrics NonPublicMetrics { get; set; }
        Metrics OrganicMetrics { get; set; }
        bool PossiblySensitive { get; set; }
        Metrics PromotedMetrics { get; set; }
        Metrics PublicMetrics { get; set; }
        dynamic[] ReferencedTweets { get; set; }
        string ReplySettings { get; set; }
        string Source { get; set; }
        dynamic Withheld { get; set; }
    }
}