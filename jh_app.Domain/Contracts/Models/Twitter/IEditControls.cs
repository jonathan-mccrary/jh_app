using System.Text.Json.Serialization;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface IEditControls
    {
        int EditsRemaining { get; set; }
        bool IsEditEligible { get; set; }
        DateTime EditableUntil { get; set; }
    }
}