using System;
using jh_app.Domain.Contracts;

namespace jh_app.DataAccess
{
    public class TwitterAPIWrapper : ITwitterAPIWrapper
    {
        public TwitterAPIWrapper()
        {
        }

        public List<ITweet> GetVolumeStreams()
        {
            throw new NotImplementedException();
        }
    }
}

