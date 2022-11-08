using System.Diagnostics;

namespace jh_app.Domain.Contracts
{
    public interface IStatsProcessing
    {
        Stopwatch RunTimer { get; }

        void Process(ITweet tweet, bool report);
    }
}