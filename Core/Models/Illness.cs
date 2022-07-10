using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Illness
    {
        [Key]
        [Required(ErrorMessage = "Illness name is a required field!")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Illness symptoms is a required field!")]
        [Column(TypeName = "varchar(1000)")]
        public string Symptoms { get; set; } = String.Empty;

        [Required(ErrorMessage = "Recommended procedures is a required field!")]
        [Column(TypeName = "varchar(1000)")]
        public string Procedures { get; set; } = String.Empty;


        [ForeignKey(nameof(HospitalUnit))]
        public string HospitalUnitName { get; set; } = String.Empty;

        public HospitalUnit HospitalUnit { get; set; } = new HospitalUnit();

        public List<Treatment> Treatments { get; set; } = new List<Treatment>();
    }
}