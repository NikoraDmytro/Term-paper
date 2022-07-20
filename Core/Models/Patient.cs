using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Patient : Person
    {
        [Timestamp]
        public DateTime DateOfAdmission { get; set; }
        
        [Required(ErrorMessage = "Diagnosis is required!")]
        public Illness? Diagnosis { get; set; }

        [Required(ErrorMessage = "An attending doctor must be assigned to every patient!")]
        public Doctor? AttendingDoctor { get; set; }
        
        [ForeignKey(nameof(HospitalWard))]
        [Required(ErrorMessage = "A ward where patient will stay is required!")]
        public int HospitalWardNumber { get; set; } 
        
        public HospitalWard? HospitalWard { get; set; }
    }
}