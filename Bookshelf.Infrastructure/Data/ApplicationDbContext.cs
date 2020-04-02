using System;
using System.Collections.Generic;
using System.Text;
using Bookshelf.Core.Enums;
using Bookshelf.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bookshelf.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public readonly ILogger _logger;
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Loan>()
            //    .HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(lo => lo.UserId);

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Loan>()
            //    .HasOne<Book>()
            //    .WithMany()
            //    .HasForeignKey(lo => lo.BookId);

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Book>()
            //    .HasOne<Author>()
            //    .WithMany()
            //    .HasForeignKey(lo => lo.AuthorId);


            modelBuilder.Seed();
        }
    }
}
