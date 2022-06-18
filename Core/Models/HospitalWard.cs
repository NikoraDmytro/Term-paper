using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CORE.Models;

public class HospitalWard
{
    [NotMapped]
    private List<Patient> _patients = new List<Patient>();
    
    [Key]
    [Required(ErrorMessage = "Hospital ward number is a required field!")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Number { get; set; }

    [Required(ErrorMessage = "The quantity of beds in the hospital ward is a required field!")]
    [Range(0, short.MaxValue, ErrorMessage = "The quantity of beds in the hospital ward must be a logically justified number!")]
    public short BedsQuantity { get; set; }
    
    [NotMapped]
    public int Occupancy => Patients.Count;
    
    public List<Patient> Patients
    {
        get => _patients;
        set
        {
            if (Occupancy > BedsQuantity)
            {
                throw new ConstraintException($"The hospital ward {Number} is already full!");
            }

            _patients = value;
        }
    }

    [ForeignKey(nameof(HospitalUnit))]
    [Required(ErrorMessage = "Unit where hospital ward is located is a required field!")]
    public string HospitalUnitName { get; set; } = String.Empty;
    
    public HospitalUnit HospitalUnit { get; set; } = new HospitalUnit();
}