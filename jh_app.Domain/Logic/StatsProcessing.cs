using System.Diagnostics;
using jh_app.Domain.Contracts;
using jh_app.Domain.Enums;
using jh_app.Domain.Extensions;
using jh_app.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace jh_app.Domain.Logic
{
    public class StatsProcessing : IStatsProcessing
    {
        private ILogger _logger;
        private IConfiguration _configuration;
        Dictionary<StatsType, IStatsWrapper> _statsWrappers;

        private int _historicalTweetsCount;
        private Stopwatch _processingTimer;
        private readonly string _separater = "*****************************************";
        private List<StatsType> _reportingTypes;
        private bool _includeHistoricalReporting;

        public StatsProcessing(ILogger<StatsProcessing> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            _statsWrappers = new Dictionary<StatsType, IStatsWrapper>();

            _historicalTweetsCount = 0;
            _processingTimer = new Stopwatch();
        }

        public void SetupProcessing(List<StatsType> reportingTypes, bool includeHistoricalReporting)
        {
            _reportingTypes = reportingTypes;
            foreach (StatsType statsType in _reportingTypes)
            {
                _statsWrappers.Add(statsType, new StatsWrapper(statsType));
            }
            _includeHistoricalReporting = includeHistoricalReporting;
        }

        public void ProcessTweets(List<ITweet> tweets, TimeSpan elapsedTime)
        {
            try
            {
                _logger.LogInformation("ProcessTweets START");
                _processingTimer.Start();
                _historicalTweetsCount += tweets.Count;
                foreach (var tweet in tweets)
                {
                    ProcessStats(tweet);
                }
                ReportStatistics(tweets.Count, elapsedTime);
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Failure in Tweets Processing:");
                _logger.LogError(ex.Message);
            }
            finally
            {
                _processingTimer.Reset();
                _logger.LogInformation("ProcessTweets END");
            }
        }

        private void ReportStatistics(int tweetsCount, TimeSpan elapsedTime)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"{_historicalTweetsCount} tweets streamed in total.");
                Console.WriteLine($"{tweetsCount} tweets streamed since last report.");

                Console.WriteLine("***Results***");
                foreach(var statsType in _reportingTypes)
                {
                    _statsWrappers[statsType].StatsList.PrintStatsResults(Convert.ToInt32(_configuration["ResultsCount"]), _includeHistoricalReporting);
                }
                
                Console.WriteLine(_separater);
                Console.WriteLine($"Processing Time: {_processingTimer.ElapsedMilliseconds} milliseconds");
                Console.WriteLine($"Total Runtime: {elapsedTime.ToString("mm\\:ss\\.ff")}");
                Console.WriteLine(_separater);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failure in Tweet Stats Reporting:");
                _logger.LogError(ex.Message);
            }
        }

        
        private void ProcessStats(ITweet tweet)
        {
            try
            {
                List<string> hashtags = null;
                List<string> mentions = null;
                foreach (var statType in _reportingTypes)
                {
                    switch (statType)
                    {
                        case (StatsType.HashtagCount):
                            
                            _statsWrappers[StatsType.HashtagCount].UpdateStatsWrapper(hashtags ?? (hashtags = tweet.GetHashTags()), 1);
                            break;
                        case (StatsType.HashtagImpressionsCount):
                            _statsWrappers[StatsType.HashtagImpressionsCount].UpdateStatsWrapper(hashtags ?? (hashtags = tweet.GetHashTags()), tweet.PublicMetrics.ImpressionCount);
                            break;
                        case (StatsType.HashtagLikesCount):
                            _statsWrappers[StatsType.HashtagLikesCount].UpdateStatsWrapper(hashtags ?? (hashtags = tweet.GetHashTags()), tweet.PublicMetrics.LikeCount);
                            break;
                        case (StatsType.HashtagQuoteTweetsCount):
                            _statsWrappers[StatsType.HashtagQuoteTweetsCount].UpdateStatsWrapper(hashtags ?? (hashtags = tweet.GetHashTags()), tweet.PublicMetrics.QuoteCount);
                            break;
                        case (StatsType.HashtagRetweetsCount):
                            _statsWrappers[StatsType.HashtagRetweetsCount].UpdateStatsWrapper(hashtags ?? (hashtags = tweet.GetHashTags()), tweet.PublicMetrics.RetweetCount);
                            break;
                        case (StatsType.HashtagTotalRetweetsCount):
                            _statsWrappers[StatsType.HashtagTotalRetweetsCount].UpdateStatsWrapper(hashtags ?? (hashtags = tweet.GetHashTags()), tweet.PublicMetrics.TotalRetweetCount);
                            break;
                        case (StatsType.MentionCount):
                            _statsWrappers[StatsType.MentionCount].UpdateStatsWrapper(mentions ?? (mentions = tweet.GetMentions()), 1);
                            break;
                        case (StatsType.MentionImpressionsCount):
                            _statsWrappers[StatsType.MentionImpressionsCount].UpdateStatsWrapper(mentions ?? (mentions = tweet.GetMentions()), tweet.PublicMetrics.ImpressionCount);
                            break;
                        case (StatsType.MentionLikesCount):
                            _statsWrappers[StatsType.MentionLikesCount].UpdateStatsWrapper(mentions ?? (mentions = tweet.GetMentions()), tweet.PublicMetrics.LikeCount);
                            break;
                        case (StatsType.MentionQuoteTweetsCount):
                            _statsWrappers[StatsType.MentionQuoteTweetsCount].UpdateStatsWrapper(mentions ?? (mentions = tweet.GetMentions()), tweet.PublicMetrics.QuoteCount);
                            break;
                        case (StatsType.MentionRetweetsCount):
                            _statsWrappers[StatsType.MentionRetweetsCount].UpdateStatsWrapper(mentions ?? (mentions = tweet.GetMentions()), tweet.PublicMetrics.RetweetCount);
                            break;
                        case (StatsType.MentionTotalRetweetsCount):
                            _statsWrappers[StatsType.MentionTotalRetweetsCount].UpdateStatsWrapper(mentions ?? (mentions = tweet.GetMentions()), tweet.PublicMetrics.TotalRetweetCount);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failure in Hashtag Processing:");
                _logger.LogError(ex.Message);
            }
        }
    }
}