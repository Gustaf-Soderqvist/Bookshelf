using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Bookshelf.Core.Enums;
using Newtonsoft.Json.Converters;

namespace Bookshelf.Core.Domain.Entities
{
    public class BookModel
    {
        public int Id { get; set; }
        public int CopyNumber { get; set; }
        public DateTime PubDate { get; set; }
        public string? Publisher { get; set; }
        public string Title { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
        public AuthorModel Author { get; set; }
        public List<LoanModel> Loans { get; set; }
        public bool Loaned { get; set; }
    }
}
