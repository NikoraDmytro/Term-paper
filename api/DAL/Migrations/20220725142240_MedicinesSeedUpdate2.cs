using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class MedicinesSeedUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ацекор",
                columns: new[] { "DosageForm", "QuantityInStock" },
                values: new object[] { "Кардіо таблетки кишковорозчинні по 100 мг", (short)1200 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ацекор",
                columns: new[] { "DosageForm", "QuantityInStock" },
                values: new object[] { "Кардіо таблетки кишковорозчинні по 100 мг acetylsalicylic acid", (short)2500 });
        }
    }
}
