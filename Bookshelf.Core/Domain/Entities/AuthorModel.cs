using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Core.Domain.Entities
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
