using System;
using System.Net.Http.Headers;
using System.Text.Json;
using jh_app.Domain.Contracts;
using jh_app.Domain.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace jh_app.DataAccess
{
    public class TwitterAPIWrapper : ITwitterAPIWrapper
    {
        public TwitterAPIWrapper()
        {
        }

        public List<Tweet?> GetVolumeStreams()
        {
            List<Tweet?> retVal = new List<Tweet?>();

            var client = new RestClient(@"https://api.twitter.com/2/tweets/sample/stream?tweet.fields=attachments,author_id,context_annotations,conversation_id,created_at,edit_controls,edit_history_tweet_ids,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,organic_metrics,possibly_sensitive,promoted_metrics,public_metrics,referenced_tweets,reply_settings,source,text,withheld&media.fields=alt_text,duration_ms,height,media_key,non_public_metrics,organic_metrics,preview_image_url,promoted_metrics,public_metrics,type,url,variants,width&poll.fields=duration_minutes,end_datetime,id,options,voting_status&user.fields=created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld&place.fields=contained_within,country,country_code,full_name,geo,id,name,place_type");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", $"Bearer {APIConstants.BearerToken}");
            request.AddHeaders(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>( "Connection", "keep-alive" ),
                new KeyValuePair<string, string>( "Accept", "*/*" ),
            });
            var stream = client.DownloadStream(request);
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = "";
                while(!string.IsNullOrEmpty((json = reader.ReadLine())))
                {
                    Console.WriteLine(json);
                    var tweetData = JsonSerializer.Deserialize<Data>(json);
                    if (tweetData != null)
                    {
                        retVal.Add(tweetData.Tweet);
                    }
                }
            }

            return retVal;
        }
    }
}