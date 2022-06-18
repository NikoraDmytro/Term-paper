using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration;

public class HospitalUnitsConfiguration: IEntityTypeConfiguration<HospitalUnit>
{
    public void Configure(EntityTypeBuilder<HospitalUnit> builder)
    {
        builder.HasData(
            new 
            {
                Name = "Хірургічне відділення",
            }, 
            new 
            {
                Name = "Пульмонологічне відділення",
            }
        );
    }
}