﻿using System.Text.Json.Serialization;

namespace jh_app.Domain.Contracts.Models.Twitter
{
    public interface ICashtag
    {
        int Start { get; set; }
        int End { get; set; }
        string Tag { get; set; }
    }
}