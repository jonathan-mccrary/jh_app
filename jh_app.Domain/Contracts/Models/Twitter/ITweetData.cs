using System.Text.Json.Serialization;
using jh_app.Domain.Models.Twitter;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface ITweetData
    {
        Tweet Tweet { get; set; }
    }
}