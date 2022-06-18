using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration;

public class HospitalUnitsHeadsConfiguration : IEntityTypeConfiguration<HospitalUnitHead>
{
    public void Configure(EntityTypeBuilder<HospitalUnitHead> builder)
    {
        builder.HasData(
            new
            {
                Name = "Олександр",
                Surname =  "Білопашенцев",
                Patronymic = "Олександрович",
                Experience = (byte)35,
                BirthDate = new DateTime(1964, 08, 18),
                ProfessionName = "Хірург",
                HospitalUnitName = "Хірургічне відділення",
            },
            new
            {
                Name = "Олена",
                Surname =  "Пасічник",
                Patronymic = "Валеріївна",
                Experience = (byte)30,
                BirthDate = new DateTime(1969, 08, 18),
                ProfessionName = "Пульмонолог",
                HospitalUnitName = "Пульмонологічне відділення"
            }
        );
    }
}