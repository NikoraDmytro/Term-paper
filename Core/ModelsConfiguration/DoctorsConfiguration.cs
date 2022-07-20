using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration
{
    public class DoctorsConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(
                new
                {
                    Name = "Олександр",
                    Surname = "Сєдих",
                    Patronymic = "Миколайович",
                    Experience = (byte)29,
                    BirthDate = new DateTime(1970, 08, 18),
                    HospitalUnitName = "Хірургічне відділення",
                },
                new
                {
                    Name = "Сергій",
                    Surname = "Суманов",
                    Patronymic = "Валерійович",
                    Experience = (byte)28,
                    BirthDate = new DateTime(1971, 08, 18),
                    HospitalUnitName = "Хірургічне відділення",
                },
                new
                {
                    Name = "Геннадій",
                    Surname = "Літвінов",
                    Patronymic = "Володимирович",
                    Experience = (byte)44,
                    BirthDate = new DateTime(1955, 08, 18),
                    HospitalUnitName = "Хірургічне відділення",
                },
                new
                {
                    Name = "Валентина",
                    Surname = "Соловьова",
                    Patronymic = "Георгіївна",
                    Experience = (byte)24,
                    BirthDate = new DateTime(1976, 08, 18),
                    HospitalUnitName = "Пульмонологічне відділення",
                },
                new
                {
                    Name = "Світлана",
                    Surname = "Шелест",
                    Patronymic = "Сергіївна",
                    Experience = (byte)17,
                    BirthDate = new DateTime(1978, 08, 18),
                    HospitalUnitName = "Пульмонологічне відділення",
                }
            );
        }
    }
}