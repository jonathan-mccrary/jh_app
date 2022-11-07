// See https://aka.ms/new-console-template for more information
using jh_app.Domain;
using jh_app.Domain.Enums;
using jh_app.Domain.Extensions;
using jh_app.Domain.Contracts;
using jh_app.DataAccess;
using jh_app.Domain.Models;

using RestSharp;

ITwitterAPIWrapper api = new TwitterAPIWrapper();
List<IStats> hashtagStats = new List<IStats>()
{
    new Stats(
        statsType: StatsType.HashtagCount,
        iterationType: IterationType.current),
    new Stats(
        statsType: StatsType.HashtagCount,
        iterationType: IterationType.historical)
};

var tweets = api.GetVolumeStreams();



//***  Build in a user listener to break cycle
//while (true)
//{
//    //Get Tweets 
//    List<Tweet> tweets = new List<Tweet>();

//    foreach (var tweet in tweets)
//    {
//        //parse Hastags
//        List<string> hashtags = tweet.GetHashTags();

//        foreach(var hashtag in hashtags)
//        {
//            foreach(var stats in hashtagStats)
//            {
//                stats.AddUpdateData(hashtag);
//            }
//        }
//    }

//    //output stats data
//    foreach (var stats in hashtagStats)
//    {
//        stats.OutputStatsData(10);
//        //reset current dictionaries before next iteration
//        if (stats.IterationType == IterationType.current)
//        {
//            stats.Data = new Dictionary<string, long>();
//        }
//    }

//    //From Twitter:With all levels of access, connection requests can be made up to 50 times per 15-minute window.
//    //wait 18 seconds for next iteration
//    Thread.Sleep(18 * 1000);
//}