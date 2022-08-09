using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class RemovedUnitHeads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumns: new[] { "Name", "Patronymic", "Surname" },
                keyValues: new object[] { "Олександр", "Олександрович", "Білопашенцев" });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumns: new[] { "Name", "Patronymic", "Surname" },
                keyValues: new object[] { "Олена", "Валеріївна", "Пасічник" });

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumns: new[] { "Name", "Patronymic", "Surname" },
                keyValues: new object[] { "Геннадій", "Володимирович", "Літвінов" });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumns: new[] { "Name", "Patronymic", "Surname" },
                keyValues: new object[] { "Олександр", "Миколайович", "Сєдих" });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumns: new[] { "Name", "Patronymic", "Surname" },
                keyValues: new object[] { "Валентина", "Георгіївна", "Соловьова" });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumns: new[] { "Name", "Patronymic", "Surname" },
                keyValues: new object[] { "Сергій", "Валерійович", "Суманов" });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumns: new[] { "Name", "Patronymic", "Surname" },
                keyValues: new object[] { "Світлана", "Сергіївна", "Шелест" });

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Doctors",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Name", "Patronymic", "Surname", "BirthDate", "Discriminator", "Experience", "HospitalUnitName", "ProfessionName" },
                values: new object[,]
                {
                    { "Геннадій", "Володимирович", "Літвінов", new DateTime(1955, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", (byte)44, "Хірургічне відділення", "Хірург" },
                    { "Олександр", "Миколайович", "Сєдих", new DateTime(1970, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", (byte)29, "Хірургічне відділення", "Хірург" },
                    { "Валентина", "Георгіївна", "Соловьова", new DateTime(1976, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", (byte)24, "Пульмонологічне відділення", "Пульмонолог" },
                    { "Сергій", "Валерійович", "Суманов", new DateTime(1971, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", (byte)28, "Хірургічне відділення", "Хірург" },
                    { "Світлана", "Сергіївна", "Шелест", new DateTime(1978, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", (byte)17, "Пульмонологічне відділення", "Пульмонолог" },
                    { "Олександр", "Олександрович", "Білопашенцев", new DateTime(1964, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "HospitalUnitHead", (byte)35, "Хірургічне відділення", "Хірург" },
                    { "Олена", "Валеріївна", "Пасічник", new DateTime(1969, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "HospitalUnitHead", (byte)30, "Пульмонологічне відділення", "Пульмонолог" }
                });
        }
    }
}
