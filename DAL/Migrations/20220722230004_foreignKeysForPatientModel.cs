using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class foreignKeysForPatientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_AttendingDoctorSurname_AttendingDoctorName_~",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HospitalWards_HospitalWardNumber",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Illnesses_DiagnosisName",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "DiagnosisName",
                table: "Patients",
                newName: "Diagnosis");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_DiagnosisName",
                table: "Patients",
                newName: "IX_Patients_Diagnosis");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalWardNumber",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AttendingDoctorPatronymic",
                table: "Patients",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_AttendingDoctorSurname_AttendingDoctorName_~",
                table: "Patients",
                columns: new[] { "AttendingDoctorSurname", "AttendingDoctorName", "AttendingDoctorPatronymic" },
                principalTable: "Doctors",
                principalColumns: new[] { "Surname", "Name", "Patronymic" });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HospitalWards_HospitalWardNumber",
                table: "Patients",
                column: "HospitalWardNumber",
                principalTable: "HospitalWards",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Illnesses_Diagnosis",
                table: "Patients",
                column: "Diagnosis",
                principalTable: "Illnesses",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_AttendingDoctorSurname_AttendingDoctorName_~",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HospitalWards_HospitalWardNumber",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Illnesses_Diagnosis",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Diagnosis",
                table: "Patients",
                newName: "DiagnosisName");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_Diagnosis",
                table: "Patients",
                newName: "IX_Patients_DiagnosisName");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalWardNumber",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "AttendingDoctorPatronymic",
                keyValue: null,
                column: "AttendingDoctorPatronymic",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AttendingDoctorPatronymic",
                table: "Patients",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_AttendingDoctorSurname_AttendingDoctorName_~",
                table: "Patients",
                columns: new[] { "AttendingDoctorSurname", "AttendingDoctorName", "AttendingDoctorPatronymic" },
                principalTable: "Doctors",
                principalColumns: new[] { "Surname", "Name", "Patronymic" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HospitalWards_HospitalWardNumber",
                table: "Patients",
                column: "HospitalWardNumber",
                principalTable: "HospitalWards",
                principalColumn: "Number");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Illnesses_DiagnosisName",
                table: "Patients",
                column: "DiagnosisName",
                principalTable: "Illnesses",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
