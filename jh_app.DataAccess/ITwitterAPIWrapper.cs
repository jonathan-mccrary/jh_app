using jh_app.Domain.Enums;

namespace jh_app.DataAccess
{
    public interface ITwitterAPIWrapper
    {
        List<StatsType> ReportingTypes { get; set; }
        bool IncludeHistoricalReporting { get; set; }
        void ProcessVolumeStreams();
    }
}