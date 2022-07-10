using System.ComponentModel.DataAnnotations;

namespace CORE.Models
{
    public class Patient : Person
    {
        [Timestamp]
        public DateTime DateOfAdmission { get; set; }

        public DateTime DateOfDischarge { get; set; }

        [Required(ErrorMessage = "Diagnosis is required!")]
        public Illness Diagnosis { get; set; } = new Illness();

        [Required(ErrorMessage = "An attending doctor must be assigned to every patient!")]
        public Doctor AttendingDoctor { get; set; } = new Doctor();
    }
}