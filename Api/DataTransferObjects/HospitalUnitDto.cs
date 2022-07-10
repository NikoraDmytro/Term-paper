namespace Api.DataTransferObjects
{
    public class HospitalUnitDto
    {
        public string Name { get; set; } = string.Empty;
        public int WardsNumber { get; set; }
        public int WorkforceSize { get; set; }
    }
}