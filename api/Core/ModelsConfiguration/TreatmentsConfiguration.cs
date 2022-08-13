using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.ModelsConfiguration
{
    public class TreatmentsConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasData
            (
                new
                {
                    Id = 1,
                    IllnessName = "Хвороба №1",
                    MedicineName = "Азимед",
                    MedicineQuantity = (byte)2,
                },
                new
                {
                    Id = 2,
                    IllnessName = "Хвороба №1",
                    MedicineName = "Алопуринол",
                    MedicineQuantity = (byte)1,
                },
                new
                {
                    Id = 3,
                    IllnessName = "Хвороба №2",
                    MedicineName = "Аміназин",
                    MedicineQuantity = (byte)5,
                },
                new
                {
                    Id = 4,
                    IllnessName = "Хвороба №2",
                    MedicineName = "Амоксил",
                    MedicineQuantity = (byte)3,
                },
                new
                {
                    Id = 5,
                    IllnessName = "Хвороба №3",
                    MedicineName = "Анальгін (амп.)",
                    MedicineQuantity = (byte)2,
                },
                new
                {
                    Id = 6,
                    IllnessName = "Хвороба №4",
                    MedicineName = "Вугілля активоване",
                    MedicineQuantity = (byte)8,

                },
                new
                {
                    Id = 7,
                    IllnessName = "Хвороба №5",
                    MedicineName = "Димедрол",
                    MedicineQuantity = (byte)1,
                },
                new
                {
                    Id = 8,
                    IllnessName = "Хвороба №5",
                    MedicineName = "Глюкоза (по 200мл)",
                    MedicineQuantity = (byte)3,
                },
                new
                {
                    Id = 9,
                    IllnessName = "Хвороба №5",
                    MedicineName = "Декасан",
                    MedicineQuantity = (byte)3,
                },
                new
                {
                    Id = 10,
                    IllnessName = "Хвороба №6",
                    MedicineName = "Ібупрофен",
                    MedicineQuantity = (byte)5,
                },
                new
                {
                    Id = 11,
                    IllnessName = "Хвороба №6",
                    MedicineName = "Магнікор",
                    MedicineQuantity = (byte)10,
                },
                new
                {
                    Id = 12,
                    IllnessName = "Хвороба №7",
                    MedicineName = "Новокаїн",
                    MedicineQuantity = (byte)2,
                },
                new
                {
                    Id = 13,
                    IllnessName = "Хвороба №7",
                    MedicineName = "Цефтріаксон",
                    MedicineQuantity = (byte)2,
                },
                new
                {
                    Id = 14,
                    IllnessName = "Хвороба №7",
                    MedicineName = "Дофамін-Дарниця",
                    MedicineQuantity = (byte)15,
                },
                new
                {
                    Id = 15,
                    IllnessName = "Неробство",
                    MedicineName = "ХНУРЕ",
                    MedicineQuantity = (byte)16,
                },
                new
                {
                    Id = 16,
                    IllnessName = "Нудьга",
                    MedicineName = "ХНУРЕ v2",
                    MedicineQuantity = (byte)20,
                }
            );
        }
    }
}