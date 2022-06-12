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
    
    [Required(ErrorMessage = "Observed symptoms of illness is a required field!")]
    [Column(TypeName = "varchar(1000)")]
    public string ObservedSymptoms { get; set; } = String.Empty;

    [Required(ErrorMessage = "Diagnosis is required!")] 
    public Illness Diagnosis { get; set; } = new Illness();
    
    [Required(ErrorMessage = "Prescribed procedures is a required field!")]
    [Column(TypeName = "varchar(1000)")]
    public string PrescribedProcedures { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Prescribed treatments is a required field!")]
    public List<PrescribedTreatment> Treatments{ get; set; } = 
        new List<PrescribedTreatment>();
}