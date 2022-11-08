using jh_app.Domain.Contracts;

namespace jh_app.Domain.Extensions
{
    public static class TweetExtensions
    {
        public static List<string> GetHashTags(this ITweet tweet)
        {
            string[] tokens = tweet?.Text?.Split(' ') ?? Array.Empty<string>();
            return tokens?.Where(p => p.StartsWith("#"))?.ToList() ?? new List<string>();
        }

        public static List<string> GetMentions(this ITweet tweet)
        {
            string[] tokens = tweet?.Text?.Split(' ') ?? Array.Empty<string>();
            return tokens?
                .Where(p => p.StartsWith("@") && p != "@")
                .Select(p => p.TrimEnd(':'))?
                .ToList() ?? new List<string>();
        }

        public static List<string> GetUrls(this ITweet tweet)
        {
            string[] tokens = tweet?.Text?.Split(' ') ?? Array.Empty<string>();
            return tokens?.Where(p => Uri.TryCreate(p, UriKind.Absolute, out var uriResult) == true)?.ToList() ?? new List<string>();
        }
    }
}