using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration;

public class HospitalWardsConfiguration: IEntityTypeConfiguration<HospitalWard>
{
    public void Configure(EntityTypeBuilder<HospitalWard> builder)
    {
        builder.HasData
        (
            new 
            {
                BedsQuantity = (short)15,
                Number = 101,
                HospitalUnitName = "Хірургічне відділення"
            },
            new 
            {
                BedsQuantity = (short)15,
                Number = 102,
                HospitalUnitName = "Хірургічне відділення"
            },
            new 
            {
                BedsQuantity = (short)10,
                Number = 103,
                HospitalUnitName = "Хірургічне відділення"
            },
            new 
            {
                BedsQuantity = (short)10,
                Number = 104,
                HospitalUnitName = "Хірургічне відділення"
            },
            new 
            {
                BedsQuantity = (short)10,
                Number = 201,
                HospitalUnitName = "Пульмонологічне відділення"
            },
            new 
            {
                BedsQuantity = (short)8,
                Number = 202,
                HospitalUnitName = "Пульмонологічне відділення"
            }
        );
    }
}