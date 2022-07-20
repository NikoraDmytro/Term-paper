using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Doctor : Person
    {
        [Required(ErrorMessage = "Doctor experience is a required property")]
        [Range(0, 70, ErrorMessage = "Doctor experience is a number from 0 to 70")]
        public byte Experience { get; set; }

        [ForeignKey(nameof(HospitalUnit))]
        [Required(ErrorMessage = "Hospital unit where doctor works is a required field!")]
        public string? HospitalUnitName { get; set; }

        public HospitalUnit? HospitalUnit { get; set; }
        
        [NotMapped]
        public string? Profession { get; set; }
    }
}