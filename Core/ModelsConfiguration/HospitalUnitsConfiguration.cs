using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration
{
    public class HospitalUnitsConfiguration : IEntityTypeConfiguration<HospitalUnit>
    {
        public void Configure(EntityTypeBuilder<HospitalUnit> builder)
        {
            builder.HasData(
                new
                {
                    Id = 1,
                    Name = "Хірургічне відділення",
                    Profession = "Хірург",
                },
                new
                {
                    Id = 2,
                    Name = "Пульмонологічне відділення",
                    Profession = "Пульмонолог",
                }
            );
        }
    }
}