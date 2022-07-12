using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Doctor : Person
    {
        [Required(ErrorMessage = "Doctor experience is a required property")]
        [Range(0, 70, ErrorMessage = "Doctor experience is a number from 0 to 70")]
        public byte Experience { get; set; }

        [ForeignKey(nameof(Profession))]
        [Required(ErrorMessage = "Doctor's profession is a required field!")]
        public string ProfessionName { get; set; } = String.Empty;
        
        public Profession? Profession { get; set; } = new Profession();
    }
}