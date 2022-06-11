using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models;

public class Doctor: Person
{
    [Required(ErrorMessage = "Doctor experience is a required property")]
    [Range(0, 70, ErrorMessage = "Doctor experience is a number from 0 to 70")]
    public byte Experience { get; set; }
    
    [Required(ErrorMessage = "Doctor's profession is a required field!")]
    public Profession Profession { get; set; } = new Profession();
}