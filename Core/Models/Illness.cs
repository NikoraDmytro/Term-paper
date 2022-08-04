using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Illness
    {
        [Key]
        [Required(ErrorMessage = "Illness name is a required field!")]
        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Illness symptoms is a required field!")]
        [Column(TypeName = "varchar(5000)")]
        public string? Symptoms { get; set; }

        [Required(ErrorMessage = "Recommended procedures is a required field!")]
        [Column(TypeName = "varchar(5000)")]
        public string? Procedures { get; set; }


        [ForeignKey(nameof(HospitalUnit))]
        [Required(ErrorMessage = "Hospital unit where disease is treated is a required field!")]
        public string? HospitalUnitName { get; set; }

        public HospitalUnit? HospitalUnit { get; set; }
        public List<Treatment> Treatments { get; set; } = new List<Treatment>();
    }
}