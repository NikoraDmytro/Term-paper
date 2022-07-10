using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration
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
                    MedicineName = "Ліки №4",
                    MedicineQuantity = (byte)2,
                },
                new
                {
                    Id = 2,
                    IllnessName = "Хвороба №1",
                    MedicineName = "Ліки №5",
                    MedicineQuantity = (byte)1,
                },
                new
                {
                    Id = 3,
                    IllnessName = "Хвороба №2",
                    MedicineName = "Ліки №8",
                    MedicineQuantity = (byte)5,
                },
                new
                {
                    Id = 4,
                    IllnessName = "Хвороба №2",
                    MedicineName = "Ліки №3",
                    MedicineQuantity = (byte)3,
                },
                new
                {
                    Id = 5,
                    IllnessName = "Хвороба №3",
                    MedicineName = "Ліки №4",
                    MedicineQuantity = (byte)2,
                },
                new
                {
                    Id = 6,
                    IllnessName = "Хвороба №4",
                    MedicineName = "Ліки №4",
                    MedicineQuantity = (byte)2,

                },
                new
                {
                    Id = 7,
                    IllnessName = "Хвороба №5",
                    MedicineName = "Ліки №1",
                    MedicineQuantity = (byte)1,
                },
                new
                {
                    Id = 8,
                    IllnessName = "Хвороба №5",
                    MedicineName = "Ліки №2",
                    MedicineQuantity = (byte)3,
                },
                new
                {
                    Id = 9,
                    IllnessName = "Хвороба №5",
                    MedicineName = "Ліки №10",
                    MedicineQuantity = (byte)3,
                }
            );
        }
    }
}