using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration
{
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
                },
                new Medicine()
                {
                    Name = "Ліки №2",
                    QuantityInStock = (short)430,
                },
                new Medicine()
                {
                    Name = "Ліки №3",
                    QuantityInStock = (short)500,
                },
                new Medicine()
                {
                    Name = "Ліки №4",
                    QuantityInStock = (short)300,
                },
                new Medicine()
                {
                    Name = "Ліки №5",
                    QuantityInStock = (short)150,
                },
                new Medicine()
                {
                    Name = "Ліки №6",
                    QuantityInStock = (short)210,
                },
                new Medicine()
                {
                    Name = "Ліки №7",
                    QuantityInStock = (short)300,
                },
                new Medicine()
                {
                    Name = "Ліки №8",
                    QuantityInStock = (short)630,
                },
                new Medicine()
                {
                    Name = "Ліки №9",
                    QuantityInStock = (short)500,
                },
                new Medicine()
                {
                    Name = "Ліки №10",
                    QuantityInStock = (short)580,
                },
                new Medicine()
                {
                    Name = "Ліки №11",
                    QuantityInStock = (short)210,
                },
                new Medicine()
                {
                    Name = "Ліки №12",
                    QuantityInStock = (short)170,
                }
            );
        }
    }
}