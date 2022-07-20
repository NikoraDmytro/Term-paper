using System.ComponentModel.DataAnnotations;
using Core.DataTransferObjects.Person;

namespace Core.DataTransferObjects.Doctor
{
    public class CreateDoctorDto: CreatePersonDto
    {
        [Required(ErrorMessage = "Не вказано досвід роботи лікаря!")]
        [Range(0, 70, ErrorMessage = "Досвід роботи - ціле число від 0 до 70!")]
        public int? Experience { get; set; }

        [Required(ErrorMessage = "Не вказано відділення де працює лікар!")]
        public string HospitalUnitName { get; set; } = String.Empty;
    }
}