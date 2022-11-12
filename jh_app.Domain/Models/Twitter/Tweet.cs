using System.Text.Json.Serialization;
using jh_app.Domain.Contracts.Models.Twitter;

namespace jh_app.Domain.Models.Twitter
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

        /// <summary>
        /// Unique identifiers indicating all versions of a Tweet.
        /// For Tweets with no edits, there will be one ID.
        /// For Tweets with an edit history, there will be multiple IDs,
        /// arranged in ascending order reflecting the order of edits.
        /// The most recent version is the last position of the array.
        /// </summary>
        [JsonPropertyName("edit_history_tweet_ids")]
        public string[] EditHistoryTweetIds { get; set; }

        /// <summary>
        /// Specifies the type of attachments (if any) present in this Tweet.
        /// </summary>
        [JsonPropertyName("attachments")]
        public dynamic Attachments { get; set; }

        /// <summary>
        /// The unique identifier of the User who posted this Tweet.
        /// </summary>
        [JsonPropertyName("author_id")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Contains context annotations for the Tweet.
        /// </summary>
        [JsonPropertyName("context_annotations")]
        public dynamic ContextAnnotations { get; set; }

        /// <summary>
        /// The Tweet ID of the original Tweet of the conversation (which includes direct replies, replies of replies).
        /// </summary>
        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }

        /// <summary>
        /// Creation time of the Tweet.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// When present, this indicates how much longer the Tweet can be edited and the number of remaining edits.
        /// Tweets are only editable for the first 30 minutes after creation and can be edited up to five times.
        /// </summary>
        [JsonPropertyName("edit_controls")]
        public EditControls EditControls { get; set; }

        /// <summary>
        /// Entities that have been parsed out of the text of the Tweet.
        /// Additionally, see entities in Twitter Objects.
        /// </summary>
        [JsonPropertyName("entities")]
        public Entities Entities { get; set; }

        /// <summary>
        /// If the represented Tweet is a reply, this field will contain the original Tweet’s author ID.This will not necessarily always be the user directly mentioned in the Tweet.
        /// </summary>
        [JsonPropertyName("in_reply_to_user_id")]
        public string InReplyToUserId { get; set; }

        /// <summary>
        /// Language of the Tweet, if detected by Twitter. Returned as a BCP47 language tag.
        /// </summary>
        [JsonPropertyName("lang")]
        public string Language { get; set; }

        /// <summary>
        /// Non-public engagement metrics for the Tweet at the time of the request.
        /// 
        /// Requires user context authentication.
        /// </summary>
        [JsonPropertyName("non_public_metrics")]
        public Metrics NonPublicMetrics { get; set; }

        /// <summary>
        /// Engagement metrics, tracked in an organic context, for the Tweet at the time of the request.
        /// 
        /// Requires user context authentication.
        /// </summary>
        [JsonPropertyName("organic_metrics")]
        public Metrics OrganicMetrics { get; set; }

        /// <summary>
        /// This field indicates content may be recognized as sensitive.
        /// The Tweet author can select within their own account preferences and choose
        /// “Mark media you tweet as having material that may be sensitive” so each Tweet created after has this flag set.
        ///
        /// This may also be judged and labeled by an internal Twitter support agent.
        /// </summary>
        [JsonPropertyName("possibly_sensitive")]
        public bool PossiblySensitive { get; set; }

        /// <summary>
        /// Engagement metrics, tracked in a promoted context, for the Tweet at the time of the request.
        ///
        /// Requires user context authentication.
        /// </summary>
        [JsonPropertyName("promoted_metrics")]
        public Metrics PromotedMetrics { get; set; }

        /// <summary>
        /// Public engagement metrics for the Tweet at the time of the request.
        /// </summary>
        [JsonPropertyName("public_metrics")]
        public Metrics PublicMetrics { get; set; }

        /// <summary>
        /// A list of Tweets this Tweet refers to. For example, if the parent Tweet is a Retweet,
        /// a Retweet with comment (also known as Quoted Tweet) or a Reply,
        /// it will include the related Tweet referenced to by its parent.
        /// </summary>
        [JsonPropertyName("referenced_tweets")]
        public dynamic[] ReferencedTweets { get; set; }

        /// <summary>
        /// Shows you who can reply to a given Tweet.
        /// Fields returned are "everyone", "mentioned_users", and "followers".
        /// </summary>
        [JsonPropertyName("reply_settings")]
        public string ReplySettings { get; set; }

        /// <summary>
        /// The name of the app the user Tweeted from.
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; set; }

        /// <summary>
        /// When present, contains withholding details for withheld content.
        /// </summary>
        [JsonPropertyName("withheld")]
        public dynamic Withheld { get; set; }
    }
}