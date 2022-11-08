using jh_app.DataAccess;

Console.WriteLine("*** Welcome to TweetStats ***");
ITwitterAPIWrapper api = new TwitterAPIWrapper();
api.ProcessVolumeStreams();