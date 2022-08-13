using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.ModelsConfiguration
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
                    QuantityInStock = (short)600,
                },
                new Medicine()
                {
                    Name = "Адреналін",
                    DosageForm = "Розчин для ін'єкцій, 1,82 мг/мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)670,
                },
                new Medicine()
                {
                    Name = "Азимед",
                    DosageForm = "Таблетки, вкриті плівковою оболонкою, по 500 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)516,
                },
                new Medicine()
                {
                    Name = "Алопуринол",
                    DosageForm = "300 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)510,
                },
                new Medicine()
                {
                    Name = "Альдазол",
                    DosageForm = "400 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)77,
                },
                new Medicine()
                {
                    Name = "Амікацид",
                    DosageForm = "Розчин для інєкцій 250 мг/мл по 4 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)68,
                },
                new Medicine()
                {
                    Name = "Аміксин ІС",
                    DosageForm = "0,125 г",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)1009,
                },
                new Medicine()
                {
                    Name = "Аміназин",
                    DosageForm = "Розчин для інєкцій 25 мг/мл по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)45,
                },
                new Medicine()
                {
                    Name = "Амінокапронова",
                    DosageForm = "Кислота розчин для інфузій по 100 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)928,
                },
                new Medicine()
                {
                    Name = "Амлодипін",
                    DosageForm = "5 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)1320,
                },
                new Medicine()
                {
                    Name = "Амоксил",
                    DosageForm = "500 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)160,
                },
                new Medicine()
                {
                    Name = "Амоксил-К (порошок)",
                    DosageForm = "Порошок для розчину для ін'єкцій 1,2 г",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)115,
                },
                new Medicine()
                {
                    Name = "Амоксил-К (табл.)",
                    DosageForm = "Таблетка вкриті плівковою оболонкою по 500мг/125мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)280
                },
                new Medicine()
                {
                    Name = "Анальгін (табл.)",
                    DosageForm = "0,5г",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)460,
                },
                new Medicine()
                {
                    Name = "Анальгін (амп.)",
                    DosageForm = "Розчин для ін'єкцій по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)1680,
                },
                new Medicine()
                {
                    Name = "Анаприлін здоров'я",
                    DosageForm = "40 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)75
                },
                new Medicine()
                {
                    Name = "Аргітек",
                    DosageForm = "Розчин для інфузій, 8 мг/мл по 250 мл у флаконі",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)64
                },
                new Medicine()
                {
                    Name = "Аріс",
                    DosageForm = "Порошок для розчину для інфузій по 1 г meropenem",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)24
                },
                new Medicine()
                {
                    Name = "Асакол",
                    DosageForm = "Таблетки, вкриті оболонкою, кишковорозчинні по 800 мг mesalazine",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)340
                },
                new Medicine()
                {
                    Name = "Асиброкс",
                    DosageForm = "200 мг acetylcysteine",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)200
                },
                new Medicine()
                {
                    Name = "Аспаркам",
                    DosageForm = "Розчин для ін'єкцій 10 мл magnesium (different salts in combination)",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)920,
                },
                new Medicine()
                {
                    Name = "Атерокард",
                    DosageForm = "75 мг clopidogrel",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)90
                },
                new Medicine()
                {
                    Name = "Ацекор",
                    DosageForm = "Кардіо таблетки кишковорозчинні по 100 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)1200
                },
                new Medicine()
                {
                    Name = "Беталок",
                    DosageForm = "Розчин для ін'єкцій 5 мл metoprolol",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)130,
                },
                new Medicine()
                {
                    Name = "Бинт не стерильний",
                    UnitOfMeasure = "шт.",
                    QuantityInStock = (short)1000
                },
                new Medicine()
                {
                    Name = "Бинт стерильний",
                    UnitOfMeasure = "шт.",
                    QuantityInStock = (short)650
                },
                new Medicine()
                {
                    Name = "Бісопрол",
                    DosageForm = "2,5 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)230
                },
                new Medicine()
                {
                    Name = "Браксон",
                    DosageForm = "Розчин для інєкцій 40 мг/мл по 2 мг",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)30
                },
                new Medicine()
                {
                    Name = "Валідол",
                    DosageForm = "0,06 г",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)103
                },
                new Medicine()
                {
                    Name = "Варфарин-ФС",
                    DosageForm = "Таблетки по 2, 5мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)80
                },
                new Medicine()
                {
                    Name = "Вітаксон",
                    DosageForm = "Розчин для інєкцій по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)644
                },
                new Medicine()
                {
                    Name = "Вугілля активоване",
                    DosageForm = "250 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)800
                },
                new Medicine()
                {
                    Name = "Галоприл",
                    DosageForm = "Розчин для ін'єкцій, 5 мг/мл в ампулі",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)74
                },
                new Medicine()
                {
                    Name = "Гекодез",
                    DosageForm = "Розчин для інфузій 200 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)242
                },
                new Medicine()
                {
                    Name = "Гентаміцин-Здоров'я",
                    DosageForm = "Розчин для ін'єкцій, 40 мг/мл, по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)250
                },
                new Medicine()
                {
                    Name = "Гепадиф",
                    DosageForm = "Порошок для приготування розчину для інєкцій",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)327
                },
                new Medicine()
                {
                    Name = "Герпевір",
                    DosageForm = "Таблетки по 400 мг по 10 таблеток у блістері",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)600
                },
                new Medicine()
                {
                    Name = "Глутаргін",
                    DosageForm = "Розчин для ін’єкцій, 40 мг/мл, по 5 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)185
                },
                new Medicine()
                {
                    Name = "Глюкоза (по 200мл)",
                    DosageForm = "Розчин для інфузій, 50 мг/мл по 200 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)1295
                },
                new Medicine()
                {
                    Name = "Глюкоза (по 400мл)",
                    DosageForm = "Розчин для інфузій, 50 мг/мл по 400 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)1200
                },
                new Medicine()
                {
                    Name = "Глюкоза (по 10мл)",
                    DosageForm = "Розчин для інфузій, 400 мг/мл по 10 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)300
                },
                new Medicine()
                {
                    Name = "Гордокс",
                    DosageForm = "Розчин для ін'єкцій, 10 000 кіод/мл по 10 мл в ампулі",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)465
                },
                new Medicine()
                {
                    Name = "Декасан",
                    DosageForm = "Розчин, 0,2 мг/мл по 200 мл",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)196
                },
                new Medicine()
                {
                    Name = "Дексаметазон (1мл)",
                    DosageForm = "Розчин для ін'єкцій по 1 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)452
                },
                new Medicine()
                {
                    Name = "Дексаметазон (4мл)",
                    DosageForm = "Розчин для ін'єкцій по 4 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)1820
                },
                new Medicine()
                {
                    Name = "Дигоксин",
                    DosageForm = "Розчин для ін'єкцій, 0,25 мг/мл по 1 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)310
                },
                new Medicine()
                {
                    Name = "Димедрол",
                    DosageForm = "Розчин для ін'єкцій, 10 мг/мл по 1 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)740
                },
                new Medicine()
                {
                    Name = "Дофамін-Дарниця",
                    DosageForm = "Концентрат для розчину для інфузій, 40 мг/мл; по 5 мл в ампулі",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)1140
                },
                new Medicine()
                {
                    Name = "Дротаверин",
                    DosageForm = "Розчин для ін'єкцій, 20 мг/мл по 2 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)547
                },
                new Medicine()
                {
                    Name = "Еналозид 25",
                    DosageForm = "Таблетки",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)360
                },
                new Medicine()
                {
                    Name = "Еноксапарин-Фармекс",
                    DosageForm = "Розчин для ін'єкцій, 10000 анти-ха мо/мл; по 0,4 мл",
                    UnitOfMeasure = "шприц.",
                    QuantityInStock = (short)829
                },
                new Medicine()
                {
                    Name = "Новокаїн",
                    DosageForm = "Розчин для ін'єкцій по 5 мл",
                    UnitOfMeasure = "амп.",
                    QuantityInStock = (short)270
                },
                new Medicine()
                {
                    Name = "Спирт етиловий",
                    DosageForm = "96% медичний",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)295
                },
                new Medicine()
                {
                    Name = "Цефтріаксон",
                    DosageForm = "Порошок для розчину для ін'єкцій 1,0 г",
                    UnitOfMeasure = "фл.",
                    QuantityInStock = (short)360
                },
                new Medicine()
                {
                    Name = "Ібупрофен",
                    DosageForm = "200 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)1150
                },
                new Medicine()
                {
                    Name = "Магнікор",
                    DosageForm = "150 мг",
                    UnitOfMeasure = "таб.",
                    QuantityInStock = (short)497
                },
                new
                {
                    Name = "ХНУРЕ",
                    DosageForm = "1,5 годинні заняття",
                    UnitOfMeasure = "пари",
                    QuantityInStock = (short)200,
                },
                new
                {
                    Name = "ХНУРЕ v2",
                    DosageForm = "1,5 годинні заняття",
                    UnitOfMeasure = "пари",
                    QuantityInStock = (short)100,
                }
            );
        }
    }
}