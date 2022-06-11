using System.ComponentModel.DataAnnotations;

namespace CORE.Models;

public class HospitalUnit
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Hospital unit name is a required field!")]
    public string Name { get; set; } = String.Empty;

    [Required(ErrorMessage = "There must be a head in every hospital department!")]
    public Doctor Head { get; set; } = new Doctor();
    
    public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    public List<Patient> Patients { get; set; } = new List<Patient>();
    public List<HospitalWard> HospitalWards { get; set; } = new List<HospitalWard>();
}
    