namespace jh_app.Domain.Contracts
{
    public interface IMention
    {
        int Start { get; set; }
        int End { get; set; }
        string UserName { get; set; }
        string Id { get; set; }
    }
}