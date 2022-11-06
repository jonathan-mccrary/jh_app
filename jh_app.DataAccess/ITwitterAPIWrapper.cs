using System;
using jh_app.Domain.Contracts;

namespace jh_app.DataAccess
{
    public interface ITwitterAPIWrapper
    {
        List<ITweet> GetVolumeStreams();
    }
}

