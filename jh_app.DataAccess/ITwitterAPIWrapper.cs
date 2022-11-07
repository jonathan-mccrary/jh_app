using System;
using jh_app.Domain.Models;

namespace jh_app.DataAccess
{
    public interface ITwitterAPIWrapper
    {
        List<Tweet?> GetVolumeStreams();
    }
}

