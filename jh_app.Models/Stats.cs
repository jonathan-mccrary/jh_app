using System;
namespace jh_app.Models
{
    public class Stats
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

