using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models;

public class Patient: Person
{
    [Timestamp]
    public DateTime DateOfAdmission { get; set; }
    
    [Required(ErrorMessage = "Patient Date of discharge is a required field!")]
    public DateTime DateOfDischarge { get; set; }
 
    [Required(ErrorMessage = "An attending doctor must be assigned to every patient!")]
    public Doctor AttendingDoctor { get; set; } = new Doctor();
}