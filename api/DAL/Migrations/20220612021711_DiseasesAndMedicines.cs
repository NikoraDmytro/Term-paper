using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class DiseasesAndMedicines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professions_HospitalUnits_RelatedHospitalUnitId",
                table: "Professions");

            migrationBuilder.RenameColumn(
                name: "RelatedHospitalUnitId",
                table: "Professions",
                newName: "HospitalUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Professions_RelatedHospitalUnitId",
                table: "Professions",
                newName: "IX_Professions_HospitalUnitId");

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

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Symptoms = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Procedures = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantityInStock = table.Column<short>(type: "smallint", nullable: false),
                    InterchangeabilityGroup = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrescribedTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicineQuantity = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    MedicineName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientSurname = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientPatronymic = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    MedicineQuantity = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    IllnessName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicineName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                name: "IX_Patients_Name",
                table: "Patients",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Name",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ObservedSymptoms",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PrescribedProcedures",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "HospitalUnitId",
                table: "Professions",
                newName: "RelatedHospitalUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Professions_HospitalUnitId",
                table: "Professions",
                newName: "IX_Professions_RelatedHospitalUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_HospitalUnits_RelatedHospitalUnitId",
                table: "Professions",
                column: "RelatedHospitalUnitId",
                principalTable: "HospitalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
