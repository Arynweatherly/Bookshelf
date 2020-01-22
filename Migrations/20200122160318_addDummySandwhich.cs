using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf35.Migrations
{
    public partial class addDummySandwhich : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a50ad5c9-1a5e-4c7c-9462-6d2fe072513e", "AQAAAAEAACcQAAAAEPMCS1CDZM/vr3tj4t0Wa37zNvQ2STuyyemo84HHD5W3+P9DLgX56m/bNYy/fmDeSg==" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", "Stephen King" },
                    { 2, "00000000-ffff-ffff-ffff-ffffffffffff", "Jersey Mike" },
                    { 3, "00000000-ffff-ffff-ffff-ffffffffffff", "Jared FFFFFogel" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "ApplicationUserId", "AuthorId", "Genre", "Rating", "Title", "YearPublished" },
                values: new object[] { 1, null, 1, "Sandwiches", 4, "Free Smells", 1998 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "ApplicationUserId", "AuthorId", "Genre", "Rating", "Title", "YearPublished" },
                values: new object[] { 2, null, 2, "Sandwiches", 5, "Jersey Subs", 2020 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "ApplicationUserId", "AuthorId", "Genre", "Rating", "Title", "YearPublished" },
                values: new object[] { 3, null, 3, "Instructional", 0, "How to make a prison sandwhich", 2015 });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ApplicationUserId", "BookId", "Text" },
                values: new object[] { 2, "00000000-ffff-ffff-ffff-ffffffffffff", 1, "the fastest delivery guys and their book" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ApplicationUserId", "BookId", "Text" },
                values: new object[] { 1, "00000000-ffff-ffff-ffff-ffffffffffff", 2, "It smells like jersey" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ApplicationUserId", "BookId", "Text" },
                values: new object[] { 3, "00000000-ffff-ffff-ffff-ffffffffffff", 3, "the worst book ever" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a35d880-899f-472d-bae1-5eb7711fedd2", "AQAAAAEAACcQAAAAEEo97tetAfNJ9Zz6ifRPHYNlcnHeIolumlNJb9Hfu9RgLSjEZtc/wL9brTRZjb84Dw==" });
        }
    }
}
