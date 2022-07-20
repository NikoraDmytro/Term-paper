using System.ComponentModel.DataAnnotations;

namespace Core.DataTransferObjects.Doctor
{
    public class UpdateDoctorExperienceDto
    {
        [Required(ErrorMessage = "Не вказано досвід роботи лікаря!")]
        [Range(0, 70, ErrorMessage = "Досвід роботи - ціле число від 0 до 70!")]
        public byte? Experience { get; set; }
    }
}