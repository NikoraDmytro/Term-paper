using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CORE.Models
{
    public class HospitalWard
    {
        [Key]
        [Required(ErrorMessage = "Hospital ward number is a required field!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }

        [Required(ErrorMessage = "The quantity of beds in the hospital ward is a required field!")]
        [Range(0, short.MaxValue, ErrorMessage = "The quantity of beds in the hospital ward must be a logically justified number!")]
        public short BedsQuantity { get; set; }
        
        [ForeignKey(nameof(HospitalUnit))]
        [Required(ErrorMessage = "Unit where hospital ward is located is a required field!")]
        public string? HospitalUnitName { get; set; }

        public HospitalUnit? HospitalUnit { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}