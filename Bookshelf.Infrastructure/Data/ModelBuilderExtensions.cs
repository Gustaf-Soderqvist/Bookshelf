﻿using Bookshelf.Core.Enums;
using Bookshelf.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test",
                    Username = "TestUser1",
                    Email = "test@bookshelfuser.net"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Test2",
                    LastName = "Test2",
                    Username = "TestUser2",
                    Email = "test2@bookshelfuser.net"
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Test3",
                    LastName = "Test3",
                    Username = "TestUser3",
                    Email = "test3@bookshelfuser.net"
                }

            );

            modelBuilder.Entity<Author>().HasData(
            new Author()
            {
                Id = 1,
                Name = "‎Eoin Colfer"
            },
            new Author()
            {
                Id = 2,
                Name = "‎‎Robert C Martin"
            },
            new Author()
            {
                Id = 3,
                Name = "‎‎Andrzej Sapkowski"
            },
            new Author()
            {
                Id = 4,
                Name = "‎‎Bea Uusma"
            },
            new Author()
            {
                Id = 5,
                Name = "John Edward Williams"
            },
            new Author()
            {
                Id = 6,
                Name = "Douglas Adams"
            }

        );

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    CopyNumber = 1,
                    PubDate = new DateTime(2001, 01, 01),
                    Publisher = "Old publisher",
                    Title = "Artemis Fowl",
                    Genre = Genre.Fantasy,
                    AuthorId = 1,

                },
                new Book()
                {
                    Id = 2,
                    CopyNumber = 1,
                    PubDate = new DateTime(2008, 01, 01),
                    Publisher = "illustrated ed",
                    Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                    Genre = Genre.Programming,
                    AuthorId = 2
                },
                new Book()
                {
                    Id = 3,
                    CopyNumber = 1,
                    PubDate = new DateTime(2008, 01, 01),
                    Publisher = "Little, Brown and Company",
                    Title = "The Last Wish",
                    Genre = Genre.Fantasy,
                    AuthorId = 3
                },
                new Book()
                {
                    Id = 4,
                    CopyNumber = 1,
                    PubDate = new DateTime(1965, 01, 01),
                    Publisher = "Viking Press",
                    Title = "Stoner",
                    Genre = Genre.Novel,
                    AuthorId = 5
                },
                new Book()
                {
                    Id = 5,
                    CopyNumber = 1,
                    PubDate = new DateTime(2008, 01, 01),
                    Publisher = "Norstedts",
                    Title = "Expeditionen: min kärlekshistoria",
                    Genre = Genre.Novel,
                    AuthorId = 4
                },
                new Book()
                {
                    Id = 6,
                    CopyNumber = 1,
                    PubDate = new DateTime(2009, 08, 14),
                    Publisher = "Pan Books Ltd",
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Genre = Genre.Novel,
                    AuthorId = 6
                }
                );
        }
    }
}