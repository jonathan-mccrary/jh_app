using System;
using jh_app.Domain.Contracts;
using jh_app.Domain.Enums;
using jh_app.Domain.Models;
using Microsoft.VisualBasic;
using System.Diagnostics;
using jh_app.Domain.Extensions;

namespace jh_app.Domain.Logic
{
    public class StatsProcessing : IStatsProcessing
    {
        private List<ITweet> _historicalTweets = new List<ITweet>();
        private List<ITweet> _currentTweets = new List<ITweet>();
        private StatsWrapper _hashtagCountStats;
        private StatsWrapper _hashtagLikesSumStats;
        private StatsWrapper _mentionCountStats;
        private StatsWrapper _mentionsLikesSumStats;

        public StatsProcessing()
        {
            RunTimer = new Stopwatch();
            _hashtagCountStats = new StatsWrapper(StatsType.HashtagCount);
            _hashtagLikesSumStats = new StatsWrapper(StatsType.HashtagLikesSum);
            _mentionCountStats = new StatsWrapper(StatsType.MentionCount);
            _mentionsLikesSumStats = new StatsWrapper(StatsType.MentionLikesSum);
        }

        public Stopwatch RunTimer { get; private set; }

        public void Process(ITweet tweet, bool report)
        {
            try
            {
                _currentTweets.Add(tweet);
                _historicalTweets.Add(tweet);

                List<string> hashtags = tweet.GetHashTags();
                _hashtagCountStats.UpdateCountStats(hashtags);
                _hashtagLikesSumStats.UpdateLikesSumStats(tweet, hashtags);

                List<string> mentions = tweet.GetMentions();
                _mentionCountStats.UpdateCountStats(mentions);
                _mentionsLikesSumStats.UpdateLikesSumStats(tweet, mentions);

                if (report)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{_historicalTweets.Count} tweets streamed in total.");
                    Console.WriteLine($"{_currentTweets.Count} tweets streamed since last report.");

                    Console.WriteLine("***Results***");
                    _hashtagCountStats.StatsList.PrintStatsResults();
                    //_hashtagLikesSumStats.StatsList.PrintStatsResults();
                    //_mentionCountStats.StatsList.PrintStatsResults();
                    //_mentionsLikesSumStats.StatsList.PrintStatsResults();
                    _currentTweets.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure in Tweet Processing:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

