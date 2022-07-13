using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class HospitalUnit
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Hospital unit name is a required field!")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Profession related to hospital unit is a required field!")]
        [Column(TypeName = "varchar(50)")]
        public string Profession { get; set; } = String.Empty;
        
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Illness> Illnesses { get; set; } = new List<Illness>();
        public List<HospitalWard> HospitalWards { get; set; } = new List<HospitalWard>();
    }
}