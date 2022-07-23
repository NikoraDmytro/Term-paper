using System.ComponentModel.DataAnnotations;
using Core.DataTransferObjects.Person;

namespace Core.DataTransferObjects.Patient;

public class CreatePatientDto: CreatePersonDto
{
    [Required(ErrorMessage = "Не вказано діагноз пацієнта!")]
    public string? Diagnosis { get; set; }

    [Required(ErrorMessage = "Не вказано ім'я персонального лікаря!")]
    public string? AttendingDoctor { get; set; }
        
    [Required(ErrorMessage = "Не вказано номер палати де буде перебувати пацієнт!")]
    public int? HospitalWardNumber { get; set; }
}