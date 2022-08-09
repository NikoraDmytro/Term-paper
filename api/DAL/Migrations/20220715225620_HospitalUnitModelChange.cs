using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class HospitalUnitModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalWards_HospitalUnits_HospitalUnitId",
                table: "HospitalWards");

            migrationBuilder.DropForeignKey(
                name: "FK_Illnesses_HospitalUnits_HospitalUnitId",
                table: "Illnesses");

            migrationBuilder.DropIndex(
                name: "IX_Illnesses_HospitalUnitId",
                table: "Illnesses");

            migrationBuilder.DropIndex(
                name: "IX_HospitalWards_HospitalUnitId",
                table: "HospitalWards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalUnits",
                table: "HospitalUnits");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_HospitalUnitId",
                table: "Doctors");

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
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HospitalUnits",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "HospitalUnitId",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "HospitalUnitId",
                table: "HospitalWards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HospitalUnits");

            migrationBuilder.DropColumn(
                name: "HospitalUnitId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "HospitalWardNumber",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalUnitName",
                table: "Illnesses",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HospitalUnitName",
                table: "HospitalWards",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HospitalUnits",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HospitalUnitName",
                table: "Doctors",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalUnits",
                table: "HospitalUnits",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalWardNumber",
                table: "Patients",
                column: "HospitalWardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Illnesses_HospitalUnitName",
                table: "Illnesses",
                column: "HospitalUnitName");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalWards_HospitalUnitName",
                table: "HospitalWards",
                column: "HospitalUnitName");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalUnitName",
                table: "Doctors",
                column: "HospitalUnitName");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitName",
                table: "Doctors",
                column: "HospitalUnitName",
                principalTable: "HospitalUnits",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalWards_HospitalUnits_HospitalUnitName",
                table: "HospitalWards",
                column: "HospitalUnitName",
                principalTable: "HospitalUnits",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Illnesses_HospitalUnits_HospitalUnitName",
                table: "Illnesses",
                column: "HospitalUnitName",
                principalTable: "HospitalUnits",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HospitalWards_HospitalWardNumber",
                table: "Patients",
                column: "HospitalWardNumber",
                principalTable: "HospitalWards",
                principalColumn: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitName",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalWards_HospitalUnits_HospitalUnitName",
                table: "HospitalWards");

            migrationBuilder.DropForeignKey(
                name: "FK_Illnesses_HospitalUnits_HospitalUnitName",
                table: "Illnesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HospitalWards_HospitalWardNumber",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HospitalWardNumber",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Illnesses_HospitalUnitName",
                table: "Illnesses");

            migrationBuilder.DropIndex(
                name: "IX_HospitalWards_HospitalUnitName",
                table: "HospitalWards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalUnits",
                table: "HospitalUnits");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_HospitalUnitName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HospitalWardNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalUnitName",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "HospitalUnitName",
                table: "HospitalWards");

            migrationBuilder.DropColumn(
                name: "HospitalUnitName",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "HospitalUnitId",
                table: "Illnesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HospitalUnitId",
                table: "HospitalWards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HospitalUnits",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HospitalUnits",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "HospitalUnitId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalUnits",
                table: "HospitalUnits",
                column: "Id");

            migrationBuilder.InsertData(
                table: "HospitalUnits",
                columns: new[] { "Id", "Name", "Profession" },
                values: new object[,]
                {
                    { 1, "Хірургічне відділення", "Хірург" },
                    { 2, "Пульмонологічне відділення", "Пульмонолог" }
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
                columns: new[] { "Name", "Patronymic", "Surname", "BirthDate", "Experience", "HospitalUnitId" },
                values: new object[,]
                {
                    { "Геннадій", "Володимирович", "Літвінов", new DateTime(1955, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)44, 1 },
                    { "Олександр", "Миколайович", "Сєдих", new DateTime(1970, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)29, 1 },
                    { "Валентина", "Георгіївна", "Соловьова", new DateTime(1976, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)24, 2 },
                    { "Сергій", "Валерійович", "Суманов", new DateTime(1971, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)28, 1 },
                    { "Світлана", "Сергіївна", "Шелест", new DateTime(1978, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)17, 2 }
                });

            migrationBuilder.InsertData(
                table: "HospitalWards",
                columns: new[] { "Number", "BedsQuantity", "HospitalUnitId" },
                values: new object[,]
                {
                    { 101, (short)15, 1 },
                    { 102, (short)15, 1 },
                    { 103, (short)10, 1 },
                    { 104, (short)10, 1 },
                    { 201, (short)10, 2 },
                    { 202, (short)8, 2 }
                });

            migrationBuilder.InsertData(
                table: "Illnesses",
                columns: new[] { "Name", "HospitalUnitId", "Procedures", "Symptoms" },
                values: new object[,]
                {
                    { "Хвороба №1", 1, "Розумний текст №1...", "Симптоми №1" },
                    { "Хвороба №2", 1, "Розумний текст №2...", "Симптоми №2" },
                    { "Хвороба №3", 1, "Розумний текст №3...", "Симптоми №3" },
                    { "Хвороба №4", 2, "Розумний текст №4...", "Симптоми №4" },
                    { "Хвороба №5", 2, "Розумний текст №5...", "Симптоми №5" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Illnesses_HospitalUnitId",
                table: "Illnesses",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalWards_HospitalUnitId",
                table: "HospitalWards",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalUnitId",
                table: "Doctors",
                column: "HospitalUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitId",
                table: "Doctors",
                column: "HospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalWards_HospitalUnits_HospitalUnitId",
                table: "HospitalWards",
                column: "HospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Illnesses_HospitalUnits_HospitalUnitId",
                table: "Illnesses",
                column: "HospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
