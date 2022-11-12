using System;
using System.ComponentModel;

namespace jh_app.Domain.Enums
{
    public enum Language
    {
        [Description("fr")]
        French,
        [Description("en")]
        English,
        [Description("ar")]
        Arabic,
        [Description("ja")]
        Japanese,
        [Description("es")]
        Spanish,
        [Description("de")]
        German,
        [Description("it")]
        Italian,
        [Description("id")]
        Indonesian,
        [Description("pt")]
        Portuguese,
        [Description("ko")]
        Korean,
        [Description("tr")]
        Turkish,
        [Description("ru")]
        Russian,
        [Description("nl")]
        Dutch,
        [Description("fil")]
        Filipino,
        [Description("msa")]
        Malay,
        [Description("zh-tw")]
        TraditionalChinese,
        [Description("zh-cn")]
        SimplifiedChinese,
        [Description("hi")]
        Hindi,
        [Description("no")]
        Norwegian,
        [Description("sv")]
        Swedish,
        [Description("fi")]
        Finnish,
        [Description("da")]
        Danish,
        [Description("pl")]
        Polish,
        [Description("hu")]
        Hungarian,
        [Description("fa")]
        Farsi,
        [Description("he")]
        Hebrew,
        [Description("ur")]
        Urdu,
        [Description("th")]
        Thai,
        [Description("en-gb")]
        EnglishUK
    }
}

