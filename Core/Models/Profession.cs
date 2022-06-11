using System.ComponentModel.DataAnnotations;

namespace CORE.Models;

public class Profession
{
    [Key]
    [Required(ErrorMessage = "Profession name is a required field!")]
    public string Name { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Profession must be related to a hospital unit")]
    public HospitalUnit RelatedHospitalUnit { get; set; } = new HospitalUnit();
}