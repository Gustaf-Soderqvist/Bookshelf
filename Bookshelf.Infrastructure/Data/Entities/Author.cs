using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Infrastructure.Data.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
