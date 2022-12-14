using System.Text.Json.Serialization;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface IMention
    {
        int Start { get; set; }
        int End { get; set; }
        string UserName { get; set; }
        string Id { get; set; }
    }
}