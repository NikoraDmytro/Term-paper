using Core.DataTransferObjects.Person;

namespace Core.DataTransferObjects.Doctor
{
    public class DoctorDto: PersonDto
    {
        public int Experience { get; set; }
        public string? Profession { get; set; }
    }
}