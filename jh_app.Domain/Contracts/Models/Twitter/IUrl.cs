using System.Text.Json.Serialization;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface IUrl
    {
        int Start { get; set; }
        int End { get; set; }
        string UrlText { get; set; }
        string ExpandedUrl { get; set; }
        string DisplayUrl { get; set; }
        int Status { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string UnwoundUrl { get; set; }
    }
}