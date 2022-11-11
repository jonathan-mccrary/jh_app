using System;
using System.ComponentModel;

namespace jh_app.Domain.Enums
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
        [Description("Mention Count")]
        MentionCount,
        [Description("Mention Impressions Count")]
        MentionImpressionsCount,
        [Description("Mention Retweets Count")]
        MentionRetweetsCount,
        [Description("Mention Quote Tweets Count")]
        MentionQuoteTweetsCount,
        [Description("Mention Total Retweets Count")]
        MentionTotalRetweetsCount,
        [Description("Mention Likes Count")]
        MentionLikesCount
    }
}

