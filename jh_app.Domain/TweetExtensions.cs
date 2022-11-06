using jh_app.Models;

namespace jh_app.Domain;
public static class TweetExtensions
{
    public static List<string> GetHashTags(this Tweet tweet)
    {
        string[] tokens = tweet.Text.Split(' ');
        return tokens?.Where(p => p.StartsWith("#"))?.ToList() ?? new List<string>();
    }

    public static List<string> GetMentions(this Tweet tweet)
    {
        string[] tokens = tweet.Text.Split(' ');
        return tokens?.Where(p => p.StartsWith("@"))?.ToList() ?? new List<string>();
    }

    public static List<string> GetUrls(this Tweet tweet)
    {
        string[] tokens = tweet.Text.Split(' ');
        return tokens?.Where(p => Uri.TryCreate(p, UriKind.Absolute, out var uriResult) == true)?.ToList() ?? new List<string>();
    }
}

