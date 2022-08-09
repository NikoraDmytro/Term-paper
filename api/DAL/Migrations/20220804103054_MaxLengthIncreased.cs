using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class MaxLengthIncreased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Symptoms",
                table: "Illnesses",
                type: "varchar(5000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Procedures",
                table: "Illnesses",
                type: "varchar(5000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Symptoms",
                table: "Illnesses",
                type: "varchar(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Procedures",
                table: "Illnesses",
                type: "varchar(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
