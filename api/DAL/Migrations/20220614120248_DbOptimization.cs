using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class DbOptimization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Professions_Name",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalUnits_Doctors_HeadSurname_HeadName_HeadPatronymic",
                table: "HospitalUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalWards_HospitalUnits_HospitalUnitId",
                table: "HospitalWards");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HospitalUnits_HospitalUnitId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Illnesses_Name",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Professions_HospitalUnits_HospitalUnitId",
                table: "Professions");

            migrationBuilder.DropTable(
                name: "PrescribedTreatments");

            migrationBuilder.DropTable(
                name: "RecommendedTreatments");

            migrationBuilder.DropIndex(
                name: "IX_Professions_HospitalUnitId",
                table: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HospitalUnitId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Name",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_HospitalWards_HospitalUnitId",
                table: "HospitalWards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalUnits",
                table: "HospitalUnits");

            migrationBuilder.DropIndex(
                name: "IX_HospitalUnits_HeadSurname_HeadName_HeadPatronymic",
                table: "HospitalUnits");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_HospitalUnitId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Name",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HospitalUnitId",
                table: "Professions");

            migrationBuilder.DropColumn(
                name: "HospitalUnitId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ObservedSymptoms",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PrescribedProcedures",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalUnitId",
                table: "HospitalWards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HospitalUnits");

            migrationBuilder.DropColumn(
                name: "HeadName",
                table: "HospitalUnits");

            migrationBuilder.DropColumn(
                name: "HeadPatronymic",
                table: "HospitalUnits");

            migrationBuilder.DropColumn(
                name: "HeadSurname",
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

            migrationBuilder.AddColumn<string>(
                name: "DiagnosisName",
                table: "Patients",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<short>(
                name: "InterchangeabilityGroup",
                table: "Medicines",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

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
                name: "Discriminator",
                table: "Doctors",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HospitalUnitName",
                table: "Doctors",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProfessionName",
                table: "Doctors",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalUnits",
                table: "HospitalUnits",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicineQuantity = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    MedicineName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IllnessName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Illnesses_IllnessName",
                        column: x => x.IllnessName,
                        principalTable: "Illnesses",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_Medicines_MedicineName",
                        column: x => x.MedicineName,
                        principalTable: "Medicines",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_HospitalUnitName",
                table: "Professions",
                column: "HospitalUnitName");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiagnosisName",
                table: "Patients",
                column: "DiagnosisName");

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

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ProfessionName",
                table: "Doctors",
                column: "ProfessionName");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_IllnessName",
                table: "Treatments",
                column: "IllnessName");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_MedicineName",
                table: "Treatments",
                column: "MedicineName");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitName",
                table: "Doctors",
                column: "HospitalUnitName",
                principalTable: "HospitalUnits",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Professions_ProfessionName",
                table: "Doctors",
                column: "ProfessionName",
                principalTable: "Professions",
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
                name: "FK_Patients_Illnesses_DiagnosisName",
                table: "Patients",
                column: "DiagnosisName",
                principalTable: "Illnesses",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_HospitalUnits_HospitalUnitName",
                table: "Professions",
                column: "HospitalUnitName",
                principalTable: "HospitalUnits",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalUnits_HospitalUnitName",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Professions_ProfessionName",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalWards_HospitalUnits_HospitalUnitName",
                table: "HospitalWards");

            migrationBuilder.DropForeignKey(
                name: "FK_Illnesses_HospitalUnits_HospitalUnitName",
                table: "Illnesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Illnesses_DiagnosisName",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Professions_HospitalUnits_HospitalUnitName",
                table: "Professions");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Professions_HospitalUnitName",
                table: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DiagnosisName",
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

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ProfessionName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HospitalUnitName",
                table: "Professions");

            migrationBuilder.DropColumn(
                name: "DiagnosisName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalUnitName",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "HospitalUnitName",
                table: "HospitalWards");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HospitalUnitName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ProfessionName",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "HospitalUnitId",
                table: "Professions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HospitalUnitId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservedSymptoms",
                table: "Patients",
                type: "varchar(1000)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PrescribedProcedures",
                table: "Patients",
                type: "varchar(1000)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "InterchangeabilityGroup",
                table: "Medicines",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "HospitalUnitId",
                table: "HospitalWards",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "HeadName",
                table: "HospitalUnits",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HeadPatronymic",
                table: "HospitalUnits",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HeadSurname",
                table: "HospitalUnits",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "HospitalUnitId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalUnits",
                table: "HospitalUnits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PrescribedTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicineName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientSurname = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientPatronymic = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicineQuantity = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribedTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescribedTreatments_Medicines_MedicineName",
                        column: x => x.MedicineName,
                        principalTable: "Medicines",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescribedTreatments_Patients_PatientSurname_PatientName_Pat~",
                        columns: x => new { x.PatientSurname, x.PatientName, x.PatientPatronymic },
                        principalTable: "Patients",
                        principalColumns: new[] { "Surname", "Name", "Patronymic" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecommendedTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IllnessName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicineName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicineQuantity = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendedTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendedTreatments_Illnesses_IllnessName",
                        column: x => x.IllnessName,
                        principalTable: "Illnesses",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendedTreatments_Medicines_MedicineName",
                        column: x => x.MedicineName,
                        principalTable: "Medicines",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_HospitalUnitId",
                table: "Professions",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalUnitId",
                table: "Patients",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Name",
                table: "Patients",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalWards_HospitalUnitId",
                table: "HospitalWards",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUnits_HeadSurname_HeadName_HeadPatronymic",
                table: "HospitalUnits",
                columns: new[] { "HeadSurname", "HeadName", "HeadPatronymic" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalUnitId",
                table: "Doctors",
                column: "HospitalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Name",
                table: "Doctors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedTreatments_MedicineName",
                table: "PrescribedTreatments",
                column: "MedicineName");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedTreatments_PatientSurname_PatientName_PatientPatro~",
                table: "PrescribedTreatments",
                columns: new[] { "PatientSurname", "PatientName", "PatientPatronymic" });

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedTreatments_IllnessName",
                table: "RecommendedTreatments",
                column: "IllnessName");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedTreatments_MedicineName",
                table: "RecommendedTreatments",
                column: "MedicineName");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalUnits_Doctors_HeadSurname_HeadName_HeadPatronymic",
                table: "HospitalUnits",
                columns: new[] { "HeadSurname", "HeadName", "HeadPatronymic" },
                principalTable: "Doctors",
                principalColumns: new[] { "Surname", "Name", "Patronymic" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalWards_HospitalUnits_HospitalUnitId",
                table: "HospitalWards",
                column: "HospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HospitalUnits_HospitalUnitId",
                table: "Patients",
                column: "HospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Illnesses_Name",
                table: "Patients",
                column: "Name",
                principalTable: "Illnesses",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_HospitalUnits_HospitalUnitId",
                table: "Professions",
                column: "HospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
