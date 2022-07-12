using System.ComponentModel.DataAnnotations;

namespace CORE.Models
{
    public class HospitalUnit
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Hospital unit name is a required field!")]
        public string Name { get; set; } = String.Empty;

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Illness> Illnesses { get; set; } = new List<Illness>();
        public List<Profession> Professions { get; set; } = new List<Profession>();
        public List<HospitalWard> HospitalWards { get; set; } = new List<HospitalWard>();
    }
}