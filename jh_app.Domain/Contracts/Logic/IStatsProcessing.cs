using jh_app.Domain.Contracts.Models.Twitter;
using jh_app.Domain.Enums;

namespace jh_app.Domain.Contracts.Logic
{
    public interface IStatsProcessing
    {
        void SetupProcessing(List<StatsType> reportingTypes, bool includeHistoricalReporting);
        void ProcessTweets(List<ITweet> tweets, TimeSpan elapsedTime);
    }
}