using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Simplification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Professions_HospitalUnits_HospitalUnitName",
                table: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Professions_HospitalUnitName",
                table: "Professions");

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
                table: "Professions",
                keyColumn: "Name",
                keyValue: "Пульмонолог");

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Name",
                keyValue: "Хірург");

            migrationBuilder.DeleteData(
                table: "HospitalUnits",
                keyColumn: "Name",
                keyValue: "Пульмонологічне відділення");

            migrationBuilder.DeleteData(
                table: "HospitalUnits",
                keyColumn: "Name",
                keyValue: "Хірургічне відділення");

            migrationBuilder.DropColumn(
                name: "HospitalUnitName",
                table: "Professions");

            migrationBuilder.DropColumn(
                name: "DateOfDischarge",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalWardNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "InterchangeabilityGroup",
                table: "Medicines");

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
                table: "Professions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalUnits",
                table: "HospitalUnits",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_HospitalUnitId",
                table: "Professions",
                column: "HospitalUnitId");

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
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_HospitalUnits_HospitalUnitId",
                table: "Professions",
                column: "HospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Professions_HospitalUnits_HospitalUnitId",
                table: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Professions_HospitalUnitId",
                table: "Professions");

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

            migrationBuilder.DropColumn(
                name: "HospitalUnitId",
                table: "Professions");

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

            migrationBuilder.AddColumn<string>(
                name: "HospitalUnitName",
                table: "Professions",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDischarge",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HospitalWardNumber",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "InterchangeabilityGroup",
                table: "Medicines",
                type: "smallint",
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

            migrationBuilder.InsertData(
                table: "HospitalUnits",
                column: "Name",
                values: new object[]
                {
                    "Пульмонологічне відділення",
                    "Хірургічне відділення"
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Name", "InterchangeabilityGroup", "QuantityInStock" },
                values: new object[,]
                {
                    { "Ліки №1", null, (short)230 },
                    { "Ліки №10", (short)2, (short)580 },
                    { "Ліки №11", null, (short)210 },
                    { "Ліки №12", null, (short)170 },
                    { "Ліки №2", null, (short)430 },
                    { "Ліки №3", null, (short)500 },
                    { "Ліки №4", null, (short)300 },
                    { "Ліки №5", (short)1, (short)150 },
                    { "Ліки №6", (short)1, (short)210 },
                    { "Ліки №7", null, (short)300 },
                    { "Ліки №8", (short)2, (short)630 },
                    { "Ліки №9", (short)2, (short)500 }
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
                table: "Professions",
                columns: new[] { "Name", "HospitalUnitName" },
                values: new object[,]
                {
                    { "Пульмонолог", "Пульмонологічне відділення" },
                    { "Хірург", "Хірургічне відділення" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Name", "Patronymic", "Surname", "BirthDate", "Experience", "HospitalUnitName", "ProfessionName" },
                values: new object[,]
                {
                    { "Геннадій", "Володимирович", "Літвінов", new DateTime(1955, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)44, "Хірургічне відділення", "Хірург" },
                    { "Олександр", "Миколайович", "Сєдих", new DateTime(1970, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)29, "Хірургічне відділення", "Хірург" },
                    { "Валентина", "Георгіївна", "Соловьова", new DateTime(1976, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)24, "Пульмонологічне відділення", "Пульмонолог" },
                    { "Сергій", "Валерійович", "Суманов", new DateTime(1971, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)28, "Хірургічне відділення", "Хірург" },
                    { "Світлана", "Сергіївна", "Шелест", new DateTime(1978, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)17, "Пульмонологічне відділення", "Пульмонолог" }
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
                name: "IX_Professions_HospitalUnitName",
                table: "Professions",
                column: "HospitalUnitName");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_HospitalUnits_HospitalUnitName",
                table: "Professions",
                column: "HospitalUnitName",
                principalTable: "HospitalUnits",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
