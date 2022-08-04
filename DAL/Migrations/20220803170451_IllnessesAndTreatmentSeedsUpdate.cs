using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class IllnessesAndTreatmentSeedsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Illnesses",
                columns: new[] { "Name", "HospitalUnitName", "Procedures", "Symptoms" },
                values: new object[,]
                {
                    { "Неробство", "Хірургічне відділення", "Регулярне відвідування лекційних і практичних онлайн занять, що проводять викладачі Харківського національного університету радіоелектроніки у Google meet. Заняття слід відвідувати 5 разів на тиждень, кожного тиждня, протягом 9 місяців, за відсутності особливих вказівок деканату ХНУРЕ.", "Хворий лежить у ліжку і нічого не хоче робити, встає з ліжка тільки аби задовольнити свої базові потреби. Спостерігається так званий синдром \"сім п'ятниць на тиждень\"." },
                    { "Нудьга", "Хірургічне відділення", "Регулярне відвідування лекційних і практичних онлайн занять, що проводять викладачі Харківського національного університету радіоелектроніки у Google meet. Заняття слід відвідувати 5 разів на тиждень, кожного тиждня, протягом 9 місяців, за відсутності особливих вказівок деканату ХНУРЕ. Задля покращення ефекту від лікування слід також приймати участь у конференціях, студенських олімпіадах чи іншою студентською активністю.", "У хворого спостерігається прагнення відмовитися від подолання труднощів, найвне стійке небажання робити вольове зусилля. В особливо важких випадках, хворий періодично плює у стелі, поки лежить або сидить, і чекає падіння слини." },
                    { "Хвороба №6", "Хірургічне відділення", "Розумний текст №6...", "Симптоми №6" },
                    { "Хвороба №7", "Хірургічне відділення", "Розумний текст №7...", "Симптоми №7" }
                });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "MedicineName",
                value: "Азимед");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "MedicineName",
                value: "Алопуринол");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "MedicineName",
                value: "Аміназин");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "MedicineName",
                value: "Амоксил");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "MedicineName",
                value: "Анальгін (амп.)");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MedicineName", "MedicineQuantity" },
                values: new object[] { "Вугілля активоване", (byte)8 });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "IllnessName",
                value: "Димедрол");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "MedicineName",
                value: "Глюкоза (по 200мл");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "MedicineName",
                value: "Декасан");

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "IllnessName", "MedicineName", "MedicineQuantity" },
                values: new object[,]
                {
                    { 10, "Хвороба №6", "Ібупрофен", (byte)5 },
                    { 11, "Хвороба №6", "Магнікор", (byte)10 },
                    { 12, "Хвороба №7", "Новокаїн", (byte)2 },
                    { 13, "Хвороба №7", "Цефтріаксон", (byte)2 },
                    { 14, "Хвороба №7", "Дофамін-Дарниця", (byte)15 },
                    { 15, "Неробство", "ХНУРЕ", (byte)16 },
                    { 16, "Нудьга", "ХНУРЕ v2", (byte)20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Неробство");

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Нудьга");

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Хвороба №6");

            migrationBuilder.DeleteData(
                table: "Illnesses",
                keyColumn: "Name",
                keyValue: "Хвороба №7");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "MedicineName",
                value: "Ліки №4");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "MedicineName",
                value: "Ліки №5");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "MedicineName",
                value: "Ліки №8");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "MedicineName",
                value: "Ліки №3");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "MedicineName",
                value: "Ліки №4");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MedicineName", "MedicineQuantity" },
                values: new object[] { "Ліки №4", (byte)2 });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "IllnessName",
                value: "Хвороба №5");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "MedicineName",
                value: "Ліки №2");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "MedicineName",
                value: "Ліки №10");
        }
    }
}
