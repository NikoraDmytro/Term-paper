namespace Core.DataTransferObjects.HospitalUnit
{
    public class HospitalUnitDto
    {
        public string Name { get; set; } = String.Empty;
        public int WardsQuantity { get; set; }
        public int TotalOccupancy { get; set; }
        public int DoctorsQuantity { get; set; }
    }
}