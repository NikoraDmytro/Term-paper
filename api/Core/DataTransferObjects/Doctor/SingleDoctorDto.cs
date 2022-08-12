using Core.DataTransferObjects.Patient;
using Core.DataTransferObjects.Person;

namespace Core.DataTransferObjects.Doctor
{
    public class SingleDoctorDto: PersonDto
    {
        public int Experience { get; set; }
        public string? Profession { get; set; }
        public List<PatientDto> Patients { get; set; } = new ();
    }
}
