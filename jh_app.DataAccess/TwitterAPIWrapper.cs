using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using jh_app.Domain.Contracts;
using jh_app.Domain.Logic;
using jh_app.Domain.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace jh_app.DataAccess
{
    public class TwitterAPIWrapper : ITwitterAPIWrapper
    {
        private readonly int _timeInterval = 10; //seconds
        private IStatsProcessing _statsProcessing;
        public TwitterAPIWrapper()
        {
            _statsProcessing = new StatsProcessing();
        }

        public void ProcessVolumeStreams()
        {
            try
            {
                _statsProcessing.RunTimer.Start();
                RestClient client;
                RestRequest request;
                SetupRestClient(out client, out request);

                Console.WriteLine("Getting Volume Stream");
                using (var stream = client.DownloadStream(request))
                {
                    if (stream != null && stream.CanRead)
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            int index = 0;

                            int nextReportingInterval = _timeInterval * 1000;
                            bool report = false;
                            while (reader != null && !reader.EndOfStream)
                            {
                                if (index % 100 == 0)
                                {
                                    Console.Write(".");
                                }
                                if (_statsProcessing.RunTimer.ElapsedMilliseconds > nextReportingInterval)
                                {
                                    nextReportingInterval += _timeInterval * 1000;
                                    report = true;
                                    Console.WriteLine();
                                }

                                string json = reader.ReadLine();
                                if (!string.IsNullOrEmpty(json))
                                {
                                    //Console.WriteLine(json);
                                    var tweetData = JsonSerializer.Deserialize<TweetData>(json);

                                    if (tweetData != null && tweetData.Tweet != null)
                                    {
                                        _statsProcessing.Process(tweetData.Tweet, report);
                                    }
                                }

                                if (report)
                                {
                                    Console.WriteLine("*****************************************");
                                    Console.WriteLine($"Total Runtime: {_statsProcessing.RunTimer.Elapsed.ToString("mm\\:ss\\.ff")}");
                                    Console.WriteLine("*****************************************");
                                    Console.WriteLine();
                                }

                                index++;
                                report = false;
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure in Volume Stream Processing:");
                Console.WriteLine(ex.Message);
            }
        }

        private static void SetupRestClient(out RestClient client, out RestRequest request)
        {
            client = new RestClient(@"https://api.twitter.com/2/tweets/sample/stream?tweet.fields=attachments,author_id,context_annotations,conversation_id,created_at,edit_controls,edit_history_tweet_ids,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,organic_metrics,possibly_sensitive,promoted_metrics,public_metrics,referenced_tweets,reply_settings,source,text,withheld&media.fields=alt_text,duration_ms,height,media_key,non_public_metrics,organic_metrics,preview_image_url,promoted_metrics,public_metrics,type,url,variants,width&poll.fields=duration_minutes,end_datetime,id,options,voting_status&user.fields=created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld&place.fields=contained_within,country,country_code,full_name,geo,id,name,place_type");
            request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", $"Bearer {APIConstants.BearerToken}");
            request.AddHeaders(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>( "Connection", "keep-alive" ),
                new KeyValuePair<string, string>( "Accept", "*/*" ),
            });
        }
    }
}