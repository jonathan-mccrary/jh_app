using System.Text.Json.Serialization;
using jh_app.Domain.Contracts.Models.Twitter;

namespace jh_app.Domain.Models.Twitter
{
    public class EditControls : IEditControls
    {
        [JsonPropertyName("edits_remaining")]
        public int EditsRemaining { get; set; }

        [JsonPropertyName("is_edit_eligible")]
        public bool IsEditEligible { get; set; }

        [JsonPropertyName("editable_until")]
        public DateTime EditableUntil { get; set; }
    }
}