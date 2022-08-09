using System.ComponentModel.DataAnnotations;

namespace Core.DataTransferObjects.Treatment;

public class CreateTreatmentDto
{
    [Required(ErrorMessage = "Не вказано назву ліків!")]
    public string? MedicineName { get; set; }
    
    [Required(ErrorMessage = "Не вказано кількість ліків!")]
    [Range(0, Byte.MaxValue, ErrorMessage = "Недопустиме значення кількості ліків!")]
    public byte? MedicineQuantity { get; set; }
}