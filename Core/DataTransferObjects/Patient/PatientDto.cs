using Core.DataTransferObjects.Person;
using Core.DataTransferObjects.Doctor;
using Core.DataTransferObjects.Illnesses;

namespace Core.DataTransferObjects.Patient
{
    public class PatientDto: PersonDto
    { 
        public IllnessDto? Diagnosis { get; set; }
        public int HospitalWardNumber { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DoctorDto? AttendingDoctor { get; set; }
    }
}