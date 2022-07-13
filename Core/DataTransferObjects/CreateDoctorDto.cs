using System.ComponentModel.DataAnnotations;

namespace Core.DataTransferObjects;

public class CreateDoctorDto
{
    [Required(ErrorMessage = "Не вказано ім'я доктора!")]
    [MaxLength(50, ErrorMessage = "Не може містити більше 50 символів!")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Не вказано прізвище доктора!")]
    [MaxLength(50, ErrorMessage = "Не може містити більше 50 символів!")]
    public string? Surname { get; set; }
    
    [MaxLength(50, ErrorMessage = "Не може містити більше 50 символів!")]
    public string Patronymic { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Не вказано досвід роботи доктора!")]
    [Range(0, 70, ErrorMessage = "Досвід роботи - ціле число від 0 до 70!")]
    public int Experience { get; set; }
    
    [Required(ErrorMessage = "Не вказано спеціальність доктора!")]
    [MaxLength(50, ErrorMessage = "Не може містити більше 50 символів!")]
    public string? Profession { get; set; }
    
    [Required(ErrorMessage = "Не вказано дату народження доктора!")]
    public DateTime BirthDate { get; set; }
}