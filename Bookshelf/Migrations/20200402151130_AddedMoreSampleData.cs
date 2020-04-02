using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Web.Migrations
{
    public partial class AddedMoreSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "‎‎Bea Uusma" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "John Edward Williams" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Douglas Adams" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CopyNumber", "Genre", "PubDate", "Publisher", "Title" },
                values: new object[] { 5, 4, 1, 25, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norstedts", "Expeditionen: min kärlekshistoria" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CopyNumber", "Genre", "PubDate", "Publisher", "Title" },
                values: new object[] { 4, 5, 1, 25, new DateTime(1965, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viking Press", "Stoner" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CopyNumber", "Genre", "PubDate", "Publisher", "Title" },
                values: new object[] { 6, 6, 1, 25, new DateTime(2009, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pan Books Ltd", "The Hitchhiker's Guide to the Galaxy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
