using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.ModelsConfiguration
{
    public class IllnessesConfiguration : IEntityTypeConfiguration<Illness>
    {
        public void Configure(EntityTypeBuilder<Illness> builder)
        {
            builder.HasData(
                new
                {
                    Name = "Хвороба №1",
                    Symptoms = "Симптоми №1",
                    Procedures = "Розумний текст №1...",
                    HospitalUnitName = "Хірургічне відділення",
                },
                new
                {
                    Name = "Хвороба №2",
                    Symptoms = "Симптоми №2",
                    Procedures = "Розумний текст №2...",
                    HospitalUnitName = "Хірургічне відділення",
                },
                new
                {
                    Name = "Хвороба №3",
                    Symptoms = "Симптоми №3",
                    Procedures = "Розумний текст №3...",
                    HospitalUnitName = "Хірургічне відділення",
                },
                new
                {
                    Name = "Хвороба №4",
                    Symptoms = "Симптоми №4",
                    Procedures = "Розумний текст №4...",
                    HospitalUnitName = "Пульмонологічне відділення",
                },
                new
                {
                    Name = "Хвороба №5",
                    Symptoms = "Симптоми №5",
                    Procedures = "Розумний текст №5...",
                    HospitalUnitName = "Пульмонологічне відділення",
                }
            );
        }
    }
}