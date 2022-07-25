using System.ComponentModel.DataAnnotations;

namespace Core.DataTransferObjects.Medicine;

public class CreateMedicineDto
{
    [Required(ErrorMessage = "Не вказано назву ліків!")]
    public string? Name { get; set; }
    public string DosageForm { get; set; } = String.Empty;

    [Required(ErrorMessage = "Не вказано одиницю виміру кількості ліків!")]
    [MaxLength(20, ErrorMessage = "Не більше 20 символів у довжину!")]
    public string? UnitOfMeasure { get; set; }

    [Required(ErrorMessage = "Не вказано кількість ліків!")]
    [Range(0, Int16.MaxValue, ErrorMessage = "Недопустиме значення кількості ліків!")]
    public short? QuantityInStock { get; set; }
}