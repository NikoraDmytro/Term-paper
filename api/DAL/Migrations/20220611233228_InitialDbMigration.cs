using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class InitialDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Experience = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    HospitalUnitId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => new { x.Surname, x.Name, x.Patronymic });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HospitalUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadSurname = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadPatronymic = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalUnits_Doctors_HeadSurname_HeadName_HeadPatronymic",
                        columns: x => new { x.HeadSurname, x.HeadName, x.HeadPatronymic },
                        principalTable: "Doctors",
                        principalColumns: new[] { "Surname", "Name", "Patronymic" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HospitalWards",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false),
                    BedsQuantity = table.Column<short>(type: "smallint", nullable: false),
                    HospitalUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalWards", x => x.Number);
                    table.ForeignKey(
                        name: "FK_HospitalWards_HospitalUnits_HospitalUnitId",
                        column: x => x.HospitalUnitId,
                        principalTable: "HospitalUnits",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelatedHospitalUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Professions_HospitalUnits_RelatedHospitalUnitId",
                        column: x => x.RelatedHospitalUnitId,
                        principalTable: "HospitalUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfAdmission = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DateOfDischarge = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AttendingDoctorSurname = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AttendingDoctorName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AttendingDoctorPatronymic = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HospitalUnitId = table.Column<int>(type: "int", nullable: true),
                    HospitalWardNumber = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => new { x.Surname, x.Name, x.Patronymic });
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_AttendingDoctorSurname_AttendingDoctorName_~",
                        columns: x => new { x.AttendingDoctorSurname, x.AttendingDoctorName, x.AttendingDoctorPatronymic },
                        principalTable: "Doctors",
                        principalColumns: new[] { "Surname", "Name", "Patronymic" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_HospitalUnits_HospitalUnitId",
                        column: x => x.HospitalUnitId,
                        principalTable: "HospitalUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_HospitalWards_HospitalWardNumber",
                        column: x => x.HospitalWardNumber,
                        principalTable: "HospitalWards",
                        principalColumn: "Number");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalUnitId",
                table: "Doctors",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Name",
                table: "Doctors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUnits_HeadSurname_HeadName_HeadPatronymic",
                table: "HospitalUnits",
                columns: new[] { "HeadSurname", "HeadName", "HeadPatronymic" });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalWards_HospitalUnitId",
                table: "HospitalWards",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AttendingDoctorSurname_AttendingDoctorName_Attendin~",
                table: "Patients",
                columns: new[] { "AttendingDoctorSurname", "AttendingDoctorName", "AttendingDoctorPatronymic" });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalUnitId",
                table: "Patients",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalWardNumber",
                table: "Patients",
                column: "HospitalWardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_RelatedHospitalUnitId",
                table: "Professions",
                column: "RelatedHospitalUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitId",
                table: "Doctors",
                column: "HospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Professions_Name",
                table: "Doctors",
                column: "Name",
                principalTable: "Professions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Professions_HospitalUnits_RelatedHospitalUnitId",
                table: "Professions");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "HospitalWards");

            migrationBuilder.DropTable(
                name: "HospitalUnits");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Professions");
        }
    }
}
