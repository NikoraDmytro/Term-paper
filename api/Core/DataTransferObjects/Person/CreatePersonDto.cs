using System.ComponentModel.DataAnnotations;

namespace Core.DataTransferObjects.Person
{
    public class CreatePersonDto
    {
        [Required(ErrorMessage = "Не вказано ім'я!")]
        [MaxLength(50, ErrorMessage = "Не може містити більше 50 символів!")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Не вказано прізвище!")]
        [MaxLength(50, ErrorMessage = "Не може містити більше 50 символів!")]
        public string Surname { get; set; } = String.Empty;

        [MaxLength(50, ErrorMessage = "Не може містити більше 50 символів!")]
        public string Patronymic { get; set; } = String.Empty;
        
        [Required(ErrorMessage = "Не вказано дату народження!")]
        public DateTime? BirthDate { get; set; }
    }
}