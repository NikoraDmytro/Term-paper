using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class MedicinesSeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Name", "DosageForm", "QuantityInStock", "UnitOfMeasure" },
                values: new object[,]
                {
                    { "L-лізину есцинат", "Розчин для ін'єкцій 0,1% 5,0", (short)600, "амп." },
                    { "Адреналін", "Розчин для ін'єкцій, 1,82 мг/мл", (short)670, "амп." },
                    { "Азимед", "Таблетки, вкриті плівковою оболонкою, по 500 мг", (short)516, "таб." },
                    { "Алопуринол", "300 мг", (short)510, "таб." },
                    { "Альдазол", "400 мг", (short)77, "таб." },
                    { "Амікацид", "Розчин для інєкцій 250 мг/мл по 4 мл", (short)68, "фл." },
                    { "Аміксин ІС", "0,125 г", (short)1009, "таб." },
                    { "Аміназин", "Розчин для інєкцій 25 мг/мл по 2 мл", (short)45, "амп." },
                    { "Амінокапронова", "Кислота розчин для інфузій по 100 мл", (short)928, "фл." },
                    { "Амлодипін", "5 мг", (short)1320, "таб." },
                    { "Амоксил", "500 мг", (short)160, "таб." },
                    { "Амоксил-К (порошок)", "Порошок для розчину для ін'єкцій 1,2 г", (short)115, "фл." },
                    { "Амоксил-К (табл.)", "Таблетка вкриті плівковою оболонкою по 500мг/125мг", (short)280, "таб." },
                    { "Анальгін (амп.)", "Розчин для ін'єкцій по 2 мл", (short)1680, "амп." },
                    { "Анальгін (табл.)", "0,5г", (short)460, "таб." },
                    { "Анаприлін здоров'я", "40 мг", (short)75, "таб." },
                    { "Аргітек", "Розчин для інфузій, 8 мг/мл по 250 мл у флаконі", (short)64, "фл." },
                    { "Аріс", "Порошок для розчину для інфузій по 1 г meropenem", (short)24, "фл." },
                    { "Асакол", "Таблетки, вкриті оболонкою, кишковорозчинні по 800 мг mesalazine", (short)340, "таб." },
                    { "Асиброкс", "200 мг acetylcysteine", (short)200, "таб." },
                    { "Аспаркам", "Розчин для ін'єкцій 10 мл magnesium (different salts in combination)", (short)920, "амп." },
                    { "Атерокард", "75 мг clopidogrel", (short)90, "таб." },
                    { "Ацекор", "Кардіо таблетки кишковорозчинні по 100 мг acetylsalicylic acid", (short)2500, "таб." },
                    { "Беталок", "Розчин для ін'єкцій 5 мл metoprolol", (short)130, "амп." },
                    { "Бинт не стерильний", null, (short)1000, "шт." },
                    { "Бинт стерильний", null, (short)650, "шт." },
                    { "Бісопрол", "2,5 мг", (short)230, "таб." },
                    { "Браксон", "Розчин для інєкцій 40 мг/мл по 2 мг", (short)30, "фл." },
                    { "Валідол", "0,06 г", (short)103, "таб." },
                    { "Варфарин-ФС", "Таблетки по 2, 5мг", (short)80, "таб." },
                    { "Вітаксон", "Розчин для інєкцій по 2 мл", (short)644, "амп." },
                    { "Вугілля активоване", "250 мг", (short)800, "таб." },
                    { "Галоприл", "Розчин для ін'єкцій, 5 мг/мл в ампулі", (short)74, "амп." },
                    { "Гекодез", "Розчин для інфузій 200 мл", (short)242, "фл." },
                    { "Гентаміцин-Здоров'я", "Розчин для ін'єкцій, 40 мг/мл, по 2 мл", (short)250, "амп." },
                    { "Гепадиф", "Порошок для приготування розчину для інєкцій", (short)327, "фл." },
                    { "Герпевір", "Таблетки по 400 мг по 10 таблеток у блістері", (short)600, "таб." },
                    { "Глутаргін", "Розчин для ін’єкцій, 40 мг/мл, по 5 мл", (short)185, "амп." },
                    { "Глюкоза (по 10мл)", "Розчин для інфузій, 400 мг/мл по 10 мл", (short)300, "амп." },
                    { "Глюкоза (по 200мл)", "Розчин для інфузій, 50 мг/мл по 200 мл", (short)1295, "фл." },
                    { "Глюкоза (по 400мл)", "Розчин для інфузій, 50 мг/мл по 400 мл", (short)1200, "фл." },
                    { "Гордокс", "Розчин для ін'єкцій, 10 000 кіод/мл по 10 мл в ампулі", (short)465, "амп." },
                    { "Декасан", "Розчин, 0,2 мг/мл по 200 мл", (short)196, "фл." },
                    { "Дексаметазон (1мл)", "Розчин для ін'єкцій по 1 мл", (short)452, "амп." },
                    { "Дексаметазон (4мл)", "Розчин для ін'єкцій по 4 мл", (short)1820, "амп." },
                    { "Дигоксин", "Розчин для ін'єкцій, 0,25 мг/мл по 1 мл", (short)310, "амп." },
                    { "Димедрол", "Розчин для ін'єкцій, 10 мг/мл по 1 мл", (short)740, "амп." },
                    { "Дофамін-Дарниця", "Концентрат для розчину для інфузій, 40 мг/мл; по 5 мл в ампулі", (short)1140, "амп." },
                    { "Дротаверин", "Розчин для ін'єкцій, 20 мг/мл по 2 мл", (short)547, "амп." },
                    { "Еналозид 25", "Таблетки", (short)360, "таб." },
                    { "Еноксапарин-Фармекс", "Розчин для ін'єкцій, 10000 анти-ха мо/мл; по 0,4 мл", (short)829, "шприц." },
                    { "Ібупрофен", "200 мг", (short)1150, "таб." },
                    { "Магнікор", "150 мг", (short)497, "таб." },
                    { "Новокаїн", "Розчин для ін'єкцій по 5 мл", (short)270, "амп." },
                    { "Спирт етиловий", "96% медичний", (short)295, "фл." },
                    { "Цефтріаксон", "Порошок для розчину для ін'єкцій 1,0 г", (short)360, "фл." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "L-лізину есцинат");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Адреналін");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Азимед");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Алопуринол");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Альдазол");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Амікацид");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Аміксин ІС");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Аміназин");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Амінокапронова");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Амлодипін");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Амоксил");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Амоксил-К (порошок)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Амоксил-К (табл.)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Анальгін (амп.)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Анальгін (табл.)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Анаприлін здоров'я");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Аргітек");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Аріс");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Асакол");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Асиброкс");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Аспаркам");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Атерокард");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ацекор");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Беталок");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Бинт не стерильний");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Бинт стерильний");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Бісопрол");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Браксон");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Валідол");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Варфарин-ФС");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Вітаксон");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Вугілля активоване");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Галоприл");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Гекодез");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Гентаміцин-Здоров'я");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Гепадиф");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Герпевір");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Глутаргін");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Глюкоза (по 10мл)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Глюкоза (по 200мл)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Глюкоза (по 400мл)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Гордокс");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Декасан");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Дексаметазон (1мл)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Дексаметазон (4мл)");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Дигоксин");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Димедрол");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Дофамін-Дарниця");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Дротаверин");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Еналозид 25");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Еноксапарин-Фармекс");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Ібупрофен");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Магнікор");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Новокаїн");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Спирт етиловий");

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Name",
                keyValue: "Цефтріаксон");
        }
    }
}
