using System.Diagnostics;
using System.Text.Json;
using jh_app.Domain.Contracts.Logic;
using jh_app.Domain.Contracts.Models.Twitter;
using jh_app.Domain.Enums;
using jh_app.Domain.Models.Twitter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace jh_app.DataAccess
{
    public class TwitterAPIWrapper : ITwitterAPIWrapper
    {
        private IStatsProcessing _statsProcessing;
        private ILogger _logger;
        private IConfiguration _configuration;
        private int _reportingInterval;
        private Stopwatch _runTimer;

        public TwitterAPIWrapper(IStatsProcessing statsProcessing,
            ILogger<TwitterAPIWrapper> logger,
            IConfiguration configuration)
        {
            _statsProcessing = statsProcessing;
           
            _logger = logger;
            _configuration = configuration;

            _reportingInterval = Convert.ToInt32(_configuration["ReportingInterval"]);
            _runTimer = new Stopwatch();
        }

        public List<StatsType> ReportingTypes { get; set; }
        public bool IncludeHistoricalReporting { get; set; }

        public void ProcessVolumeStreams()
        {
            try
            {
                _logger.LogInformation("ProcessVolumeStreams START");
                _runTimer.Start();
                _statsProcessing.SetupProcessing(ReportingTypes, IncludeHistoricalReporting);
                
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
                            int nextReportingInterval = _reportingInterval * 1000;
                            List<ITweet> tweets = new List<ITweet>();
                            while (reader != null && !reader.EndOfStream)
                            {
                                if (index % 100 == 0)
                                {
                                    Console.Write(".");
                                }

                                ReadTweet(reader, tweets);

                                if (_runTimer.ElapsedMilliseconds > nextReportingInterval)
                                {
                                    nextReportingInterval += _reportingInterval * 1000;
                                    _statsProcessing.ProcessTweets(tweets, _runTimer.Elapsed);
                                    tweets.Clear();
                                }

                                index++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failure in Volume Stream Processing:");
                _logger.LogError(ex.Message);
            }
            finally
            {
                _logger.LogInformation("ProcessVolumeStreams END");
            }
        }

        private void ReadTweet(StreamReader reader, List<ITweet> tweets)
        {
            try
            {
                string? json = reader.ReadLine();
                if (!string.IsNullOrEmpty(json))
                {
                    var tweetData = JsonSerializer.Deserialize<TweetData>(json);

                    if (tweetData != null && tweetData.Tweet != null)
                    {
                        _logger.LogTrace($"Tweet Text: {tweetData.Tweet.Text}");
                        tweets.Add(tweetData.Tweet);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failure in ReadTweet:");
                _logger.LogError(ex.Message);
            }
        }

        private void SetupRestClient(out RestClient client, out RestRequest request)
        {
            client = new RestClient(_configuration["BaseURL"] ?? string.Empty);
            request = new RestRequest();
            try
            {
                request.Method = Method.Get;
                request.AddHeader("Authorization", $"Bearer {_configuration["BearerToken"]}");
                request.AddHeaders(new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>( "Connection", "keep-alive" ),
                    new KeyValuePair<string, string>( "Accept", "*/*" ),
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to setup RestClient");
                _logger.LogError(message: ex.Message);
            }
        }
    }
}