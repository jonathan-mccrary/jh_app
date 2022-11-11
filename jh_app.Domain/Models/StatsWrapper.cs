using System;
using jh_app.Domain.Contracts;
using jh_app.Domain.Enums;

namespace jh_app.Domain.Models
{
    public class StatsWrapper : IStatsWrapper
    {
        public StatsWrapper(StatsType statsType)
        {
            StatsList = new List<IStats>()
            {
                new Stats(
                    statsType: statsType,
                    iterationType: IterationType.Current),
                new Stats(
                    statsType: statsType,
                    iterationType: IterationType.Historical)
            };
        }

        public List<IStats> StatsList { get; private set; }
    }
}