using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Patient : Person
    {
        [Timestamp]
        public DateTime DateOfAdmission { get; set; }
        
        [ForeignKey(nameof(Illness))]
        [Required(ErrorMessage = "Diagnosis is required!")]
        public string? Diagnosis { get; set; }

        [Required(ErrorMessage = "Attending doctor name is a required field!")]
        public string? AttendingDoctorName { get; set; }

        [Required(ErrorMessage = "Attending doctor surname is a required field!")]
        public string? AttendingDoctorSurname { get; set; }

        public string? AttendingDoctorPatronymic { get; set; }
        
        [ForeignKey(nameof(HospitalWard))]
        [Required(ErrorMessage = "A ward where patient will stay is required!")]
        public int HospitalWardNumber { get; set; } 
        
        public Illness? Illness { get; set; }
        
        [ForeignKey(nameof(AttendingDoctorSurname) + "," +
                    nameof(AttendingDoctorName) + "," + 
                    nameof(AttendingDoctorPatronymic))]
        public Doctor? AttendingDoctor { get; set; }
        public HospitalWard? HospitalWard { get; set; }
    }
}