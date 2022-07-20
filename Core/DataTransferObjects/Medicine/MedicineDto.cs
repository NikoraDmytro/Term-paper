using System.ComponentModel.DataAnnotations;

namespace Core.DataTransferObjects.Medicine;

public class MedicineDto
{
    [Required(ErrorMessage = "Не вказано назву ліків!")]
    public string Name { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Не вказано кількість ліків!")]
    [Range(0, Int16.MaxValue, ErrorMessage = "Недопустиме значення кількості ліків!")]
    public short? Quantity { get; set; }
}