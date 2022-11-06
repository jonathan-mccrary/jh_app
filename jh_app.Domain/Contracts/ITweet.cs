using jh_app.Domain.Models;

namespace jh_app.Domain.Contracts
{
    public interface ITweet
    {
        string Id { get; set; }
        string Text { get; set; }
        string[] EditHistoryTweetIds { get; set; }
        object Attachments { get; set; }
        string AuthorId { get; set; }
        object ContextAnnotations { get; set; }
        string ConversationId { get; set; }
        DateTime CreatedAt { get; set; }
        object EditControls { get; set; }
        object Entities { get; set; }
        string InReplyToUserId { get; set; }
        string Language { get; set; }
        Metrics NonPublicMetrics { get; set; }
        Metrics OrganicMetrics { get; set; }
        bool PossiblySensitive { get; set; }
        Metrics PromotedMetrics { get; set; }
        Metrics PublicMetrics { get; set; }
        object[] ReferencedTweets { get; set; }
        string ReplySettings { get; set; }
        string Source { get; set; }
        object Withheld { get; set; }
    }
}