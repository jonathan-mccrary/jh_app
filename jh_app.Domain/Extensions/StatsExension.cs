using System;
using System.ComponentModel;
using jh_app.Domain.Contracts;
using jh_app.Domain.Enums;
using jh_app.Domain.Models;

namespace jh_app.Domain.Extensions
{
    public static class StatsExension
    {
        public static void AddUpdateDataCount(this IStats stat, string key)
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

        public static void AddUpdateDataSum(this IStats stat, string key, long? value)
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

        public static void UpdateCountStats(this StatsWrapper countStats, List<string> items)
        {
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var stats in countStats.StatsList)
                    {
                        stats.AddUpdateDataCount(item);
                    }
                }
            }   
        }

        public static void UpdateLikesSumStats(this StatsWrapper likesCountStats, ITweet tweet, List<string> items)
        {
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var stats in likesCountStats.StatsList)
                    {
                        stats.AddUpdateDataSum(item, tweet.PublicMetrics.LikeCount);
                    }
                }
            }
        }

        public static void PrintStatsResults(this List<IStats> statsList)
        {
            //output stats data
            foreach (var stats in statsList)
            {
                stats.OutputStatsData(10);
                //reset current dictionaries before next iteration
                if (stats.IterationType == IterationType.Current)
                {
                    stats.Data.Clear();
                }
            }
        }
    }
}