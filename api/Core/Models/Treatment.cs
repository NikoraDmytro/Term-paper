using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity of medicine is a required field!")]
        [Range(0, Byte.MaxValue, ErrorMessage = "Quantity of medicines must be a logically justified number!")]
        public byte MedicineQuantity { get; set; }

        [ForeignKey(nameof(Medicine))]
        [Required(ErrorMessage = "Medicine name is a required field!")]
        public string? MedicineName { get; set; }

        [ForeignKey(nameof(Illness))]
        [Required(ErrorMessage = "Illness name is a required field!")]
        public string? IllnessName { get; set; }

        public Medicine? Medicine { get; set; }
        public Illness? Illness { get; set; }
    }
}