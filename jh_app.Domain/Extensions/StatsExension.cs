using System;
using System.ComponentModel;
using jh_app.Domain.Models;

namespace jh_app.Domain.Extensions
{
    public static class StatsExension
    {
        public static void AddUpdateData(this Stats stat, string key)
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

        public static void OutputStatsData(this Stats stat, int topRecordCount)
        {
            var sortedDictionary = new SortedDictionary<string, long>(stat.Data);
            var topRecords = sortedDictionary.OrderByDescending(p => p.Value).Take(topRecordCount);

            Console.WriteLine($"Top {topRecordCount} {stat.IterationType.ToString()} {stat.StatsType.Description()}");
            int index = 1;
            foreach (var record in topRecords)
            {
                Console.WriteLine($"{index}) {record.Key}: {record.Value}");
                index++;
            }
        }
    }
}