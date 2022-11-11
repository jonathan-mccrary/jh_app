namespace jh_app.Domain.Contracts
{
    public interface IHashtag
    {
        int Start { get; set; }
        int End { get; set; }
        string Tag { get; set; }
    }
}