using Core.DataTransferObjects.Treatment;

namespace Core.DataTransferObjects.Illnesses
{
    public class IllnessDto
    {
        public string Name { get; set; } = String.Empty;
        public string Symptoms { get; set; } = String.Empty;
        public string Procedures { get; set; } = String.Empty;
        
        public IEnumerable<TreatmentDto>? Treatments { get; set; }
    }
}