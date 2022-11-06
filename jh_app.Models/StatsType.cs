using System;
using System.ComponentModel;

namespace jh_app.Models
{
    public enum StatsType
    {
        [Description("Hashtag Count")]
        HashtagCount,
        [Description("Hashtag Impressions Count")]
        HashtagImpressionsCount,
        [Description("Hashtag Retweets Count")]
        HashtagRetweetsCount,
        [Description("Hashtag Quote Tweets Count")]
        HashtagQuoteTweetsCount,
        [Description("Hashtag Total Retweets Count")]
        HashtagTotalRetweetsCount,
        [Description("Hashtag Likes Count")]
        HashtagLikesCount,
        [Description("Hashtag Original Post Count")]
        HashtagOriginalPostCount,
        [Description("Mention Count")]
        MentionCount,
        [Description("Hastag Impressions Count")]
        HastagImpressionsCount,
        [Description("Mention Retweets Count")]
        MentionRetweetsCount,
        [Description("Mention Quote Tweets Count")]
        MentionQuoteTweetsCount,
        [Description("Mention Total Retweets Count")]
        MentionTotalRetweetsCount,
        [Description("Mention Likes Count")]
        MentionLikesCount,
        [Description("Mention Original Post Count")]
        MentionOriginalPostCount,
    }
}

