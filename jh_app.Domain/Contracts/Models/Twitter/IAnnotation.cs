using System.Text.Json.Serialization;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface IAnnotation
    {
        int Start { get; set; }
        int End { get; set; }
        decimal Probability { get; set; }
        string Type { get; set; }
        string NormalizedText { get; set; }
    }
}