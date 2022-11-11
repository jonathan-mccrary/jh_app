using System;
using jh_app.Domain.Models;
using System.Text.Json.Serialization;

namespace jh_app.Domain.Contracts
{
    public interface IEntities
    {
        Hashtag[] Hashtags { get; set; }

        Mention[] Mentions { get; set; }
    }
}