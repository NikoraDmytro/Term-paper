using Core.DataTransferObjects.Person;
using Core.DataTransferObjects.Doctor;
using Core.DataTransferObjects.Illnesses;

namespace Core.DataTransferObjects.Patient
{
    public class PatientDto: PersonDto
    { 
        public int HospitalWardNumber { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string Diagnosis { get; set; } = String.Empty;
        public string AttendingDoctor { get; set; } = String.Empty;
    }
}