using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bookshelf.Core.Enums;
using Bookshelf.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookshelf.Infrastructure.Data
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
    public class DatabaseInitializer : IDatabaseInitializer
    {
        public readonly ApplicationDbContext _context;
        public readonly ILogger _logger;

        public DatabaseInitializer(ApplicationDbContext context, ILogger<DatabaseInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            IList<User> users = new List<User>();

            users.Add(new User() { FirstName = "Test", LastName = "Test", Username = "TestUser1", Email = "test@bookshelfuser.net" });
            users.Add(new User() { FirstName = "Test2", LastName = "Test2", Username = "TestUser2", Email = "test2@bookshelfuser.net" });
            users.Add(new User() { FirstName = "Test3", LastName = "Test3", Username = "TestUser3", Email = "test3@bookshelfuser.net" });
            _context.Users.AddRange(users);
            _logger.LogInformation("Users has been added");

            IList<Book> books = new List<Book>();
            books.Add(new Book()
            {
                CopyNumber = 1,
                PubDate = new DateTime(2001 - 01 - 01),
                Publisher = "Old publisher",
                Title = "Artemis Fowl",
                Genre = Genre.Fantasy,
            });
            books.Add(new Book()
            {
                CopyNumber = 1,
                PubDate = new DateTime(2008 - 01 - 01),
                Publisher = "illustrated ed",
                Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                Genre = Genre.Programming,
            });
            books.Add(new Book()
            {
                CopyNumber = 1,
                PubDate = new DateTime(2008 - 01 - 01),
                Publisher = "Little, Brown and Company",
                Title = "The Last Wish",
                Genre = Genre.Fantasy,
            });

            _context.Books.AddRange(books);
            _logger.LogInformation("Books has been added");

            _context.SaveChanges();
            _logger.LogInformation("Completed");
        }
    }
}
