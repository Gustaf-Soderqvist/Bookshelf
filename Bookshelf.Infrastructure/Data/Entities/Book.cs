using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Bookshelf.Core.Enums;
using Newtonsoft.Json.Converters;

namespace Bookshelf.Infrastructure.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int CopyNumber { get; set; }
        public DateTime PubDate { get; set; }
        public string? Publisher { get; set; }
        public string Title { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Genre? Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
