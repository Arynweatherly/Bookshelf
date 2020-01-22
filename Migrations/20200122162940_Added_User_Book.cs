using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf35.Migrations
{
    public partial class Added_User_Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f55c8c14-c780-43d4-9aca-55bad8b3ceee", "AQAAAAEAACcQAAAAELC1Bg8dK697Qpcbj+o+BS98SFVR1AnNzUNk5NXsmtbTfYTOE91aBfgcOm6iYQhsJA==" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "00000000-ffff-ffff-ffff-ffffffffffff");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a50ad5c9-1a5e-4c7c-9462-6d2fe072513e", "AQAAAAEAACcQAAAAEPMCS1CDZM/vr3tj4t0Wa37zNvQ2STuyyemo84HHD5W3+P9DLgX56m/bNYy/fmDeSg==" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: null);
        }
    }
}
