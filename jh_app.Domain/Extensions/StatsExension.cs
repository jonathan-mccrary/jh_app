using jh_app.Domain.Contracts.Models;
using jh_app.Domain.Enums;

namespace jh_app.Domain.Extensions
{
    public static class StatsExension
    {
        public static void AddUpdateStatsData(this IStats stat, string key)
        {
            if (stat.Data.ContainsKey(key))
            {
                stat.Data[key]++;
            }
            else
            {
                stat.Data.Add(key, 1);
            }
        }

        public static void AddUpdateStatsData(this IStats stat, string key, long? value)
        {
            if (value.HasValue)
            {
                if (stat.Data.ContainsKey(key))
                {
                    stat.Data[key] += value.Value;
                }
                else
                {
                    stat.Data.Add(key, value.Value);
                }
            }
        }

        public static void UpdateStatsWrapper(this IStatsWrapper countStats, string key)
        {
            foreach (var stats in countStats.StatsList)
            {
                stats.AddUpdateStatsData(key, 1);
            }
        }

        public static void UpdateStatsWrapper(this IStatsWrapper countStats, string key, long? count)
        {
            foreach (var stats in countStats.StatsList)
            {
                stats.AddUpdateStatsData(key, count);
            }
        }

        public static void UpdateStatsWrapper(this IStatsWrapper countStats, List<string> items)
        {
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var stats in countStats.StatsList)
                    {
                        stats.AddUpdateStatsData(item);
                    }
                }
            }
        }

        public static void UpdateStatsWrapper(this IStatsWrapper countStats, List<string> items, long? count)
        {
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var stats in countStats.StatsList)
                    {
                        stats.AddUpdateStatsData(item, count);
                    }
                }
            }
        }

        public static void OutputStatsData(this IStats stat, int topRecordCount)
        {
            var topRecords = stat.Data.OrderByDescending(p => p.Value).Take(topRecordCount);

            Console.WriteLine($"Top {topRecordCount} {stat.IterationType.ToString()} {stat.StatsType.Description()}");
            int index = 1;
            foreach (var record in topRecords)
            {
                Console.WriteLine($"{index}) {record.Key}: {record.Value}");
                index++;
            }
            Console.WriteLine();
        }

        public static void PrintStatsResults(this List<IStats> statsList, int count, bool includeHistorical)
        {
            //output stats data
            foreach (var stats in statsList)
            {
                //reset current dictionaries before next iteration
                if (stats.IterationType == IterationType.Current)
                {
                    stats.OutputStatsData(count);
                    stats.Data.Clear();
                }
                else if (includeHistorical
                    && stats.IterationType == IterationType.Historical)
                {
                    stats.OutputStatsData(count);
                }
            }
        }
    }
}