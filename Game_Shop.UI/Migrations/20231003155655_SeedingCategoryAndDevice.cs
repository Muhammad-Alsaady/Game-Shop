using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Shop.UI.Migrations
{
    public partial class SeedingCategoryAndDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Action" },
                    { (byte)2, "Adventure" },
                    { (byte)3, "Racing" },
                    { (byte)4, "Puzzle" },
                    { (byte)5, "Role-Playing" },
                    { (byte)6, "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Devics",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { (byte)1, "bi bi-playstation", "Play Station" },
                    { (byte)2, "bi bi-pc-display-horizontal", "PC" },
                    { (byte)3, "bi bi-xbox", "X-Box" },
                    { (byte)4, "bi bi-phone", "Mobile Phone" },
                    { (byte)5, "bi bi-nintendo-switch", "Nintendo-Switch" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "Devics",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Devics",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Devics",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Devics",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Devics",
                keyColumn: "Id",
                keyValue: (byte)5);
        }
    }
}
