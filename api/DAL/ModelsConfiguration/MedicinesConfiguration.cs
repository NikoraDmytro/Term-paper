using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.ModelsConfiguration
{
    public class MedicinesConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasData
            (
                new Medicine()
                {
                    Name = "L-лізину есцинат",
                    DosageForm = "Розчин для ін'єкцій 0,1% 5,0",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 600,
                },
                new Medicine()
                {
                    Name = "Адреналін",
                    DosageForm = "Розчин для ін'єкцій, 1,82 мг/мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 670,
                },
                new Medicine()
                {
                    Name = "Азимед",
                    DosageForm = "Таблетки, вкриті плівковою оболонкою, по 500 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 516,
                },
                new Medicine()
                {
                    Name = "Алопуринол",
                    DosageForm = "300 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 510,
                },
                new Medicine()
                {
                    Name = "Альдазол",
                    DosageForm = "400 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 77,
                },
                new Medicine()
                {
                    Name = "Амікацид",
                    DosageForm = "Розчин для інєкцій 250 мг/мл по 4 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 68,
                },
                new Medicine()
                {
                    Name = "Аміксин ІС",
                    DosageForm = "0,125 г",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 1009,
                },
                new Medicine()
                {
                    Name = "Аміназин",
                    DosageForm = "Розчин для інєкцій 25 мг/мл по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 45,
                },
                new Medicine()
                {
                    Name = "Амінокапронова",
                    DosageForm = "Кислота розчин для інфузій по 100 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 928,
                },
                new Medicine()
                {
                    Name = "Амлодипін",
                    DosageForm = "5 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 1320,
                },
                new Medicine()
                {
                    Name = "Амоксил",
                    DosageForm = "500 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 160,
                },
                new Medicine()
                {
                    Name = "Амоксил-К (порошок)",
                    DosageForm = "Порошок для розчину для ін'єкцій 1,2 г",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 115,
                },
                new Medicine()
                {
                    Name = "Амоксил-К (табл.)",
                    DosageForm = "Таблетка вкриті плівковою оболонкою по 500мг/125мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 280
                },
                new Medicine()
                {
                    Name = "Анальгін (табл.)",
                    DosageForm = "0,5г",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 460,
                },
                new Medicine()
                {
                    Name = "Анальгін (амп.)",
                    DosageForm = "Розчин для ін'єкцій по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 1680,
                },
                new Medicine()
                {
                    Name = "Анаприлін здоров'я",
                    DosageForm = "40 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 75
                },
                new Medicine()
                {
                    Name = "Аргітек",
                    DosageForm = "Розчин для інфузій, 8 мг/мл по 250 мл у флаконі",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 64
                },
                new Medicine()
                {
                    Name = "Аріс",
                    DosageForm = "Порошок для розчину для інфузій по 1 г meropenem",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 24
                },
                new Medicine()
                {
                    Name = "Асакол",
                    DosageForm = "Таблетки, вкриті оболонкою, кишковорозчинні по 800 мг mesalazine",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 340
                },
                new Medicine()
                {
                    Name = "Асиброкс",
                    DosageForm = "200 мг acetylcysteine",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 200
                },
                new Medicine()
                {
                    Name = "Аспаркам",
                    DosageForm = "Розчин для ін'єкцій 10 мл magnesium (different salts in combination)",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 920,
                },
                new Medicine()
                {
                    Name = "Атерокард",
                    DosageForm = "75 мг clopidogrel",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 90
                },
                new Medicine()
                {
                    Name = "Ацекор",
                    DosageForm = "Кардіо таблетки кишковорозчинні по 100 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 1200
                },
                new Medicine()
                {
                    Name = "Беталок",
                    DosageForm = "Розчин для ін'єкцій 5 мл metoprolol",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 130,
                },
                new Medicine()
                {
                    Name = "Бинт не стерильний",
                    UnitOfMeasure = "шт.",
                    QuantityInStock = 1000
                },
                new Medicine()
                {
                    Name = "Бинт стерильний",
                    UnitOfMeasure = "шт.",
                    QuantityInStock = 650
                },
                new Medicine()
                {
                    Name = "Бісопрол",
                    DosageForm = "2,5 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 230
                },
                new Medicine()
                {
                    Name = "Браксон",
                    DosageForm = "Розчин для інєкцій 40 мг/мл по 2 мг",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 30
                },
                new Medicine()
                {
                    Name = "Валідол",
                    DosageForm = "0,06 г",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 103
                },
                new Medicine()
                {
                    Name = "Варфарин-ФС",
                    DosageForm = "Таблетки по 2, 5мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 80
                },
                new Medicine()
                {
                    Name = "Вітаксон",
                    DosageForm = "Розчин для інєкцій по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 644
                },
                new Medicine()
                {
                    Name = "Вугілля активоване",
                    DosageForm = "250 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 800
                },
                new Medicine()
                {
                    Name = "Галоприл",
                    DosageForm = "Розчин для ін'єкцій, 5 мг/мл в ампулі",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 74
                },
                new Medicine()
                {
                    Name = "Гекодез",
                    DosageForm = "Розчин для інфузій 200 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 242
                },
                new Medicine()
                {
                    Name = "Гентаміцин-Здоров'я",
                    DosageForm = "Розчин для ін'єкцій, 40 мг/мл, по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 250
                },
                new Medicine()
                {
                    Name = "Гепадиф",
                    DosageForm = "Порошок для приготування розчину для інєкцій",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 327
                },
                new Medicine()
                {
                    Name = "Герпевір",
                    DosageForm = "Таблетки по 400 мг по 10 таблеток у блістері",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 600
                },
                new Medicine()
                {
                    Name = "Глутаргін",
                    DosageForm = "Розчин для ін’єкцій, 40 мг/мл, по 5 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 185
                },
                new Medicine()
                {
                    Name = "Глюкоза (по 200мл)",
                    DosageForm = "Розчин для інфузій, 50 мг/мл по 200 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 1295
                },
                new Medicine()
                {
                    Name = "Глюкоза (по 400мл)",
                    DosageForm = "Розчин для інфузій, 50 мг/мл по 400 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 1200
                },
                new Medicine()
                {
                    Name = "Глюкоза (по 10мл)",
                    DosageForm = "Розчин для інфузій, 400 мг/мл по 10 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 300
                },
                new Medicine()
                {
                    Name = "Гордокс",
                    DosageForm = "Розчин для ін'єкцій, 10 000 кіод/мл по 10 мл в ампулі",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 465
                },
                new Medicine()
                {
                    Name = "Декасан",
                    DosageForm = "Розчин, 0,2 мг/мл по 200 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 196
                },
                new Medicine()
                {
                    Name = "Дексаметазон (1мл)",
                    DosageForm = "Розчин для ін'єкцій по 1 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 452
                },
                new Medicine()
                {
                    Name = "Дексаметазон (4мл)",
                    DosageForm = "Розчин для ін'єкцій по 4 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 1820
                },
                new Medicine()
                {
                    Name = "Дигоксин",
                    DosageForm = "Розчин для ін'єкцій, 0,25 мг/мл по 1 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 310
                },
                new Medicine()
                {
                    Name = "Димедрол",
                    DosageForm = "Розчин для ін'єкцій, 10 мг/мл по 1 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 740
                },
                new Medicine()
                {
                    Name = "Дофамін-Дарниця",
                    DosageForm = "Концентрат для розчину для інфузій, 40 мг/мл; по 5 мл в ампулі",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 1140
                },
                new Medicine()
                {
                    Name = "Дротаверин",
                    DosageForm = "Розчин для ін'єкцій, 20 мг/мл по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 547
                },
                new Medicine()
                {
                    Name = "Еналозид 25",
                    DosageForm = "Таблетки",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 360
                },
                new Medicine()
                {
                    Name = "Еноксапарин-Фармекс",
                    DosageForm = "Розчин для ін'єкцій, 10000 анти-ха мо/мл; по 0,4 мл",
                    UnitOfMeasure = "шприц.",
                    QuantityInStock = 829
                },
                new Medicine()
                {
                    Name = "Новокаїн",
                    DosageForm = "Розчин для ін'єкцій по 5 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = 270
                },
                new Medicine()
                {
                    Name = "Спирт етиловий",
                    DosageForm = "96% медичний",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 295
                },
                new Medicine()
                {
                    Name = "Цефтріаксон",
                    DosageForm = "Порошок для розчину для ін'єкцій 1,0 г",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = 360
                },
                new Medicine()
                {
                    Name = "Ібупрофен",
                    DosageForm = "200 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 1150
                },
                new Medicine()
                {
                    Name = "Магнікор",
                    DosageForm = "150 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = 497
                }
            );
        }
    }
}