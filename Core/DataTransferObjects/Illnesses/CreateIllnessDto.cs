using System.ComponentModel.DataAnnotations;
using Core.DataTransferObjects.Treatment;

namespace Core.DataTransferObjects.Illnesses
{
    public class CreateIllnessDto
    {
        [Required(ErrorMessage = "Не вказано назву хвороби!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Не вказано симптоми хвороби!")]
        public string? Symptoms { get; set; }

        [Required(ErrorMessage = "Не вказано необхідні процедури лікування хвороби!")]
        public string? Procedures { get; set; }

        [Required(ErrorMessage = "Не вказано віддідення, яке спеціалізується на даній хворобі!")]
        public string? HospitalUnitName { get; set; }

        [Required(ErrorMessage = "Не вказано необхідні ліки, для лікування хвороби!")]
        public IEnumerable<CreateTreatmentDto>? Treatments { get; set; }
    }
}