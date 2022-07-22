using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.DataTransferObjects.Medicine;

namespace Core.DataTransferObjects.Illnesses
{
    public class IllnessDto
    {
        [Required(ErrorMessage = "Не вказано назву хвороби!")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Не вказано симптоми хвороби!")]
        public string Symptoms { get; set; } = String.Empty;

        [Required(ErrorMessage = "Не вказано необхідні процедури лікування хвороби!")]
        public string Procedures { get; set; } = String.Empty;
        
        [Required(ErrorMessage = "Не вказано віддідення, яке спеціалізується на даній хворобі!")]
        public string HospitalUnitName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Не вказано необхідні ліки, для лікування хвороби!")]
        public IEnumerable<MedicineDto>? Treatments { get; set; }
    }
}