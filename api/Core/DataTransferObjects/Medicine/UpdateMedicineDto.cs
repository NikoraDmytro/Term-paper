using System.ComponentModel.DataAnnotations;

namespace Core.DataTransferObjects.Medicine;

public class UpdateMedicineDto
{
    [Required(ErrorMessage = "Не вказано назву ліків!")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Не вказано кількість ліків!")]
    [Range(0, Int16.MaxValue, ErrorMessage = "Недопустиме значення кількості ліків!")]
    public short? Quantity { get; set; }
}