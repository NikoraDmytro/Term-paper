using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration;

public class ProfessionsConfiguration : IEntityTypeConfiguration<Profession>
{
    public void Configure(EntityTypeBuilder<Profession> builder)
    {
        builder.HasData
        (
            new
            {
                Name = "Хірург",
                HospitalUnitName = "Хірургічне відділення"
            },
            new
            {
                Name = "Пульмонолог",
                HospitalUnitName = "Пульмонологічне відділення"
            }
        );
    }
}