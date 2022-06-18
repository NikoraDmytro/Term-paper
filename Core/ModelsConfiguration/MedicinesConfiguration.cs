using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration;

public class MedicinesConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.HasData
        (
            new Medicine()
            {
                Name = "Ліки №1",
                QuantityInStock = (short)230,
                InterchangeabilityGroup = null,
            },
            new Medicine()
            {
                Name = "Ліки №2",
                QuantityInStock = (short)430,
                InterchangeabilityGroup = null,
            },
            new Medicine()
            {
                Name = "Ліки №3",
                QuantityInStock = (short)500,
                InterchangeabilityGroup = null,
            },
            new Medicine()
            {
                Name = "Ліки №4",
                QuantityInStock = (short)300,
                InterchangeabilityGroup = null,
            },
            new Medicine()
            {
                Name = "Ліки №5",
                QuantityInStock = (short)150,
                InterchangeabilityGroup = (short)1,
            },
            new Medicine()
            {
                Name = "Ліки №6",
                QuantityInStock = (short)210,
                InterchangeabilityGroup = (short)1,
            },
            new Medicine()
            {
                Name = "Ліки №7",
                QuantityInStock = (short)300,
                InterchangeabilityGroup = null,
            },
            new Medicine()
            {
                Name = "Ліки №8",
                QuantityInStock = (short)630,
                InterchangeabilityGroup = (short)2,
            },
            new Medicine()
            {
                Name = "Ліки №9",
                QuantityInStock = (short)500,
                InterchangeabilityGroup = (short)2
            },
            new Medicine()
            {
                Name = "Ліки №10",
                QuantityInStock = (short)580,
                InterchangeabilityGroup = (short)2
            },
            new Medicine()
            {
                Name = "Ліки №11",
                QuantityInStock = (short)210,
                InterchangeabilityGroup = null,
            },
            new Medicine()
            {
                Name = "Ліки №12",
                QuantityInStock = (short)170,
                InterchangeabilityGroup = null,
            }
        );
    }
}