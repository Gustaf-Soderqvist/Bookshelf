using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Infrastructure.Data.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime DateTimeOut { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DateReturned { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
