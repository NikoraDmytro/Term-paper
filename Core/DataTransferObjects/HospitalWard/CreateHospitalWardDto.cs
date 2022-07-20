using System.ComponentModel.DataAnnotations;

namespace Core.DataTransferObjects.HospitalWard
{
    public class CreateHospitalWardDto
    {
        [Required(ErrorMessage = "Не вказана кількість ліжко-місць в палаті!")]
        [Range(0, short.MaxValue, ErrorMessage = "Неприпустиме значення кількості ліжко-місць!")]
        public int? BedsQuantity { get; set; }
        
        [Required(ErrorMessage = "Не вказано назву відділення, де знаходиться палата!")]
        public string HospitalUnitName { get; set; } = String.Empty;
    }
}