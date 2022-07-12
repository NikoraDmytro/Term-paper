using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration
{
    public class ProfessionsConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.HasData
            (
                new
                {
                    Name = "Хірург",
                    HospitalUnitId = 1
                },
                new
                {
                    Name = "Пульмонолог",
                    HospitalUnitId = 2
                }
            );
        }
    }
}