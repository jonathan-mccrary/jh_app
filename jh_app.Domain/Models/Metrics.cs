using System;
using System.Text.Json.Serialization;
using jh_app.Domain.Contracts;

namespace jh_app.Domain.Models
{
    public class Metrics : IMetrics
    {
        /// <summary>
        /// Impressions
        /// 
        /// A count of how many times the Tweet has been viewed (not unique by user). A view is counted if any part of the Tweet is visible on the screen.
        /// </summary>
        [JsonPropertyName("impression_count")]
        public long? ImpressionCount { get; set; }

        /// <summary>
        /// Retweets
        ///
        /// A count of how many times the Tweet has been Retweeted.
        /// Please note: This does not include Quote Tweets (“Retweets with comment”).
        /// </summary>
        [JsonPropertyName("retweet_count")]
        public long? RetweetCount { get; set; }

        /// <summary>
        /// Quote Tweets
        ///
        /// A count of how many times the Tweet has been Retweeted with a new comment (message). 
        /// </summary>
        [JsonPropertyName("quote_count")]
        public long? QuoteCount { get; set; }

        /// <summary>
        /// Total Retweets
        /// 
        /// To get the "Retweets and comments" total as displayed on the Twitter clients, simply add retweet_count and quote_count.
        /// </summary>
        public long? TotalRetweetCount { get { return RetweetCount ?? 0 + QuoteCount ?? 0; } }

        /// <summary>
        /// Likes
        ///
        /// A count of how many times the Tweet has been liked.
        /// </summary>
        [JsonPropertyName("like_count")]
        public long? LikeCount { get; set; }

        /// <summary>
        /// Replies
        ///
        /// A count of how many times the Tweet has been replied to.
        /// </summary>
        [JsonPropertyName("reply_count")]
        public long? Reply_Count { get; set; }

        /// <summary>
        /// URL Link Clicks
        ///
        /// A count of the number of times a user clicks on a URL link or URL preview card in a Tweet.
        /// </summary>
        [JsonPropertyName("url_link_clicks")]
        public long? UrlLinkClicks { get; set; }

        /// <summary>
        /// User Profile Clicks
        ///
        /// A count of the number of times a user clicks the following portions of a Tweet: display name, user name, profile picture.
        /// </summary>
        [JsonPropertyName("user_profile_clicks")]
        public long? UserProfileClicks { get; set; }

        /// <summary>
        /// Video views
        ///
        /// A count of how many times the video included in the Tweet has been viewed.
        /// </summary>
        [JsonPropertyName("view_count")]
        public long? ViewCount { get; set; }


        /// <summary>
        /// Video view quartiles - 0%
        ///
        /// The number of users who played through to each quartile in a video. This reflects the number of quartile views across all Tweets in which the given video has been posted.
        /// </summary>
        [JsonPropertyName("playback_0_count")]
        public long? Playback0Count { get; set; }

        /// <summary>
        /// Video view quartiles - 25%
        ///
        /// The number of users who played through to each quartile in a video. This reflects the number of quartile views across all Tweets in which the given video has been posted.
        /// </summary>
        [JsonPropertyName("playback_25_count")]
        public long? Playback25Count { get; set; }

        /// <summary>
        /// Video view quartiles - 50%
        ///
        /// The number of users who played through to each quartile in a video. This reflects the number of quartile views across all Tweets in which the given video has been posted.
        /// </summary>
        [JsonPropertyName("playback_50_count")]
        public long? Playback50Count { get; set; }

        /// <summary>
        /// Video view quartiles - 75%
        ///
        /// The number of users who played through to each quartile in a video. This reflects the number of quartile views across all Tweets in which the given video has been posted.
        /// </summary>
        [JsonPropertyName("playback_75_count")]
        public long? Playback75Count { get; set; }


        /// <summary>
        /// Video view quartiles - 100%
        ///
        /// The number of users who played through to each quartile in a video. This reflects the number of quartile views across all Tweets in which the given video has been posted.
        /// </summary>
        [JsonPropertyName("playback_100_count")]
        public long? Playback100Count { get; set; }

    }
}

