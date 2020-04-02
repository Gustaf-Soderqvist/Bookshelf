using System;
using System.Collections.Generic;
using System.Text;
using Bookshelf.Core.Enums;

namespace Bookshelf.Infrastructure.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int CopyNumber { get; set; }
        public DateTime PubDate { get; set; }
        public string? Publisher { get; set; }
        public string Title { get; set; }
        public Genre? Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
