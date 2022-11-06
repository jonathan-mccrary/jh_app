using System;
using System.ComponentModel;
using jh_app.Models;

namespace jh_app.Domain
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

            string iterationType = stat.IsCurrent ? "current" : "historical";
            Console.WriteLine($"Top {topRecordCount} {iterationType} {stat.StatsType.Description()}");
            int index = 1;
            foreach (var record in topRecords)
            {
                Console.WriteLine($"{index}) {record.Key}: {record.Value}");
                index++;
            }
        }

        public static string ToDescription<TEnum>(this TEnum EnumValue) where TEnum : struct
        {
            return Enumerations.GetEnumDescription((Enum)(object)((TEnum)EnumValue));
        }
    }
}