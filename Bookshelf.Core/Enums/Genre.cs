using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bookshelf.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Genre
    {
        Fantasy,
        Adventure,
        Romance,
        Contemporary,
        Dystopian,
        Mystery,
        Horror,
        Thriller,
        Paranormal,
        Historical_fiction,
        Science_Fiction,
        Memoir,
        Cooking,
        Art,
        Self_help,
        Development,
        Motivational,
        Health,
        History,
        Travel,
        Guide,
        Families_Relationships,
        Humor,
        Children,
        Programming,
        Novel

    }
}
