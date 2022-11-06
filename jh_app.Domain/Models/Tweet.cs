using System.Text.Json.Serialization;
using jh_app.Domain.Contracts;

namespace jh_app.Domain.Models
{
    public class Tweet : ITweet
    {
        /// <summary>
        /// The unique identifier of the requested Tweet.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The actual UTF-8 text of the Tweet. See twitter-text for details on what characters are currently considered valid.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("edit_history_tweet_ids")]
        public string[] EditHistoryTweetIds { get; set; }

        [JsonPropertyName("attachments")]
        public object Attachments { get; set; }

        [JsonPropertyName("author_id")]
        public string AuthorId { get; set; }

        [JsonPropertyName("context_annotations")]
        public object ContextAnnotations { get; set; }

        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("edit_controls")]
        public object EditControls { get; set; }

        [JsonPropertyName("entities")]
        public object Entities { get; set; }

        [JsonPropertyName("in_reply_to_user_id")]
        public string InReplyToUserId { get; set; }

        [JsonPropertyName("lang")]
        public string Language { get; set; }

        [JsonPropertyName("non_public_metrics")]
        public Metrics NonPublicMetrics { get; set; }

        [JsonPropertyName("organic_metrics")]
        public Metrics OrganicMetrics { get; set; }

        [JsonPropertyName("possibly_sensitive")]
        public bool PossiblySensitive { get; set; }

        [JsonPropertyName("promoted_metrics")]
        public Metrics PromotedMetrics { get; set; }

        [JsonPropertyName("public_metrics")]
        public Metrics PublicMetrics { get; set; }

        [JsonPropertyName("referenced_tweets")]
        public object[] ReferencedTweets { get; set; }

        [JsonPropertyName("reply_settings")]
        public string ReplySettings { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("withheld")]
        public object Withheld { get; set; }
    }
}