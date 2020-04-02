﻿// <auto-generated />
using System;
using Bookshelf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bookshelf.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bookshelf.Infrastructure.Data.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "‎Eoin Colfer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "‎‎Robert C Martin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "‎‎Andrzej Sapkowski"
                        });
                });

            modelBuilder.Entity("Bookshelf.Infrastructure.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CopyNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Genre")
                        .HasColumnType("int");

                    b.Property<DateTime>("PubDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CopyNumber = 1,
                            Genre = 0,
                            PubDate = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Old publisher",
                            Title = "Artemis Fowl"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            CopyNumber = 1,
                            Genre = 24,
                            PubDate = new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "illustrated ed",
                            Title = "Clean Code: A Handbook of Agile Software Craftsmanship"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            CopyNumber = 1,
                            Genre = 0,
                            PubDate = new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Little, Brown and Company",
                            Title = "The Last Wish"
                        });
                });

            modelBuilder.Entity("Bookshelf.Infrastructure.Data.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReturned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Bookshelf.Infrastructure.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@bookshelfuser.net",
                            FirstName = "Test",
                            LastName = "Test",
                            Username = "TestUser1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "test2@bookshelfuser.net",
                            FirstName = "Test2",
                            LastName = "Test2",
                            Username = "TestUser2"
                        },
                        new
                        {
                            Id = 3,
                            Email = "test3@bookshelfuser.net",
                            FirstName = "Test3",
                            LastName = "Test3",
                            Username = "TestUser3"
                        });
                });

            modelBuilder.Entity("Bookshelf.Infrastructure.Data.Entities.Book", b =>
                {
                    b.HasOne("Bookshelf.Infrastructure.Data.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookshelf.Infrastructure.Data.Entities.Loan", b =>
                {
                    b.HasOne("Bookshelf.Infrastructure.Data.Entities.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookshelf.Infrastructure.Data.Entities.User", "Users")
                        .WithMany("Loans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
