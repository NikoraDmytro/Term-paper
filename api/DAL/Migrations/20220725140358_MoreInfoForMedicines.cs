using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class MoreInfoForMedicines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №1");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №10");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №11");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №12");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №2");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №3");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №4");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №5");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №6");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №7");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №8");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №9");

            migrationBuilder.AddColumn<string>(
                name: "DosageForm",
                table: "Medicines",
                type: "varchar(100)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                table: "Medicines",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosageForm",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "Medicines");

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Name", "QuantityInStock" },
                values: new object[,]
                {
                    { "Ліки №1", (short)230 },
                    { "Ліки №10", (short)580 },
                    { "Ліки №11", (short)210 },
                    { "Ліки №12", (short)170 },
                    { "Ліки №2", (short)430 },
                    { "Ліки №3", (short)500 },
                    { "Ліки №4", (short)300 },
                    { "Ліки №5", (short)150 },
                    { "Ліки №6", (short)210 },
                    { "Ліки №7", (short)300 },
                    { "Ліки №8", (short)630 },
                    { "Ліки №9", (short)500 }
                });
        }
    }
}
