using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Profession
    {
        [Key]
        [Required(ErrorMessage = "Profession name is a required field!")]
        public string Name { get; set; } = String.Empty;

        [ForeignKey(nameof(HospitalUnit))]
        [Required(ErrorMessage = "Profession must be related to a hospital unit!")]
        public string HospitalUnitName { get; set; } = String.Empty;

        public HospitalUnit HospitalUnit { get; set; } = new HospitalUnit();
    }
}