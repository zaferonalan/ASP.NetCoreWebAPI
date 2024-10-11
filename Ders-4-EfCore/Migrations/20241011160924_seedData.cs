using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ders_4_EfCore.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 1, 75m, "Karagöz Ve Hacıvat" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 2, 175m, "Mesnevi" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 3, 375m, "Devlet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
