using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration { 
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
                    HospitalUnitId = 1
                },
                new
                {
                    BedsQuantity = (short)15,
                    Number = 102,
                    HospitalUnitId = 1
                },
                new
                {
                    BedsQuantity = (short)10,
                    Number = 103,
                    HospitalUnitId = 1
                },
                new
                {
                    BedsQuantity = (short)10,
                    Number = 104,
                    HospitalUnitId = 1
                },
                new
                {
                    BedsQuantity = (short)10,
                    Number = 201,
                    HospitalUnitId = 2
                },
                new
                {
                    BedsQuantity = (short)8,
                    Number = 202,
                    HospitalUnitId = 2
                }
            );
        }
    }
}