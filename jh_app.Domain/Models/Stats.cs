using jh_app.Domain.Contracts.Models;
using jh_app.Domain.Enums;

namespace jh_app.Domain.Models
{
    public class Stats : IStats
    {
        public Stats(StatsType statsType, IterationType iterationType)
        {
            StatsType = statsType;
            IterationType = iterationType;
            Data = new Dictionary<string, long>();
        }

        public StatsType StatsType { get; private set; }
        public IterationType IterationType { get; private set; }
        public Dictionary<string, long> Data { get; set; }
    }
}