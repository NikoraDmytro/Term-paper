using System.ComponentModel.DataAnnotations;

namespace CORE.Models;

public class RecommendedTreatment
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Quantity of medicine is a required field!")]
    [Range(0, Byte.MaxValue, ErrorMessage = "Quantity of medicines must be a logically justified number!")]
    public byte MedicineQuantity { get; set; }
    
    [Required(ErrorMessage = "Illness is a required field!")]
    public Illness Illness { get; set; } = new Illness();

    [Required(ErrorMessage = "Medicine is a required field!")]
    public Medicine Medicine { get; set; } = new Medicine();
}