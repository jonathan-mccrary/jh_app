using jh_app.Domain.Enums;

namespace jh_app.Domain.Contracts
{
    public interface IStats
    {
        StatsType StatsType { get; }
        IterationType IterationType { get; }
        Dictionary<string, long> Data { get; set; }
    }
}