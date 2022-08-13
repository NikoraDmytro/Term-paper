using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.ModelsConfiguration
{
    public class HospitalUnitsConfiguration : IEntityTypeConfiguration<HospitalUnit>
    {
        public void Configure(EntityTypeBuilder<HospitalUnit> builder)
        {
            builder.HasData(
                new
                {
                    Name = "Хірургічне відділення",
                    Profession = "Хірург",
                },
                new
                {
                    Name = "Пульмонологічне відділення",
                    Profession = "Пульмонолог",
                }
            );
        }
    }
}