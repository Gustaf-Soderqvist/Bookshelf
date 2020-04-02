using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Core.Domain.Entities
{
    public class LoanModel
    {
        public int Id { get; set; }
        public DateTime DateTimeOut { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DateReturned { get; set; }
        public int UserId { get; set; }
        public UserModel Users { get; set; }
        public int BookId { get; set; }
        public BookModel Book { get; set; }
    }
}
