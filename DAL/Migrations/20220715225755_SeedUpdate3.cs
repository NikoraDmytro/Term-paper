using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class SeedUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HospitalUnits",
                columns: new[] { "Name", "Profession" },
                values: new object[,]
                {
                    { "Пульмонологічне відділення", "Пульмонолог" },
                    { "Хірургічне відділення", "Хірург" }
                });

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

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Name", "Patronymic", "Surname", "BirthDate", "Experience", "HospitalUnitName" },
                values: new object[,]
                {
                    { "Геннадій", "Володимирович", "Літвінов", new DateTime(1955, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)44, "Хірургічне відділення" },
                    { "Олександр", "Миколайович", "Сєдих", new DateTime(1970, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)29, "Хірургічне відділення" },
                    { "Валентина", "Георгіївна", "Соловьова", new DateTime(1976, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)24, "Пульмонологічне відділення" },
                    { "Сергій", "Валерійович", "Суманов", new DateTime(1971, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)28, "Хірургічне відділення" },
                    { "Світлана", "Сергіївна", "Шелест", new DateTime(1978, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)17, "Пульмонологічне відділення" }
                });

            migrationBuilder.InsertData(
                table: "HospitalWards",
                columns: new[] { "Number", "BedsQuantity", "HospitalUnitName" },
                values: new object[,]
                {
                    { 101, (short)15, "Хірургічне відділення" },
                    { 102, (short)15, "Хірургічне відділення" },
                    { 103, (short)10, "Хірургічне відділення" },
                    { 104, (short)10, "Хірургічне відділення" },
                    { 201, (short)10, "Пульмонологічне відділення" },
                    { 202, (short)8, "Пульмонологічне відділення" }
                });

            migrationBuilder.InsertData(
                table: "Illnesses",
                columns: new[] { "Name", "HospitalUnitName", "Procedures", "Symptoms" },
                values: new object[,]
                {
                    { "Хвороба №1", "Хірургічне відділення", "Розумний текст №1...", "Симптоми №1" },
                    { "Хвороба №2", "Хірургічне відділення", "Розумний текст №2...", "Симптоми №2" },
                    { "Хвороба №3", "Хірургічне відділення", "Розумний текст №3...", "Симптоми №3" },
                    { "Хвороба №4", "Пульмонологічне відділення", "Розумний текст №4...", "Симптоми №4" },
                    { "Хвороба №5", "Пульмонологічне відділення", "Розумний текст №5...", "Симптоми №5" }
                });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "IllnessName", "MedicineName", "MedicineQuantity" },
                values: new object[,]
                {
                    { 1, "Хвороба №1", "Ліки №4", (byte)2 },
                    { 2, "Хвороба №1", "Ліки №5", (byte)1 },
                    { 3, "Хвороба №2", "Ліки №8", (byte)5 },
                    { 4, "Хвороба №2", "Ліки №3", (byte)3 },
                    { 5, "Хвороба №3", "Ліки №4", (byte)2 },
                    { 6, "Хвороба №4", "Ліки №4", (byte)2 },
                    { 7, "Хвороба №5", "Ліки №1", (byte)1 },
                    { 8, "Хвороба №5", "Ліки №2", (byte)3 },
                    { 9, "Хвороба №5", "Ліки №10", (byte)3 }
                });
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

            migrationBuilder.DeleteData(
                table: "HospitalWards",
                keyColumn: "Number",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "HospitalWards",
                keyColumn: "Number",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "HospitalWards",
                keyColumn: "Number",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "HospitalWards",
                keyColumn: "Number",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "HospitalWards",
                keyColumn: "Number",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "HospitalWards",
                keyColumn: "Number",
                keyValue: 202);

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
                keyValue: "Ліки №6");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №7");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ліки №9");

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Хвороба №1");

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Хвороба №2");

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Хвороба №3");

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Хвороба №4");

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Хвороба №5");

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
                keyValue: "Ліки №8");

            migrationBuilder.DeleteData(
                table: "HospitalUnits",
                keyColumn: "Name",
                keyValue: "Пульмонологічне відділення");

            migrationBuilder.DeleteData(
                table: "HospitalUnits",
                keyColumn: "Name",
                keyValue: "Хірургічне відділення");
        }
    }
}
