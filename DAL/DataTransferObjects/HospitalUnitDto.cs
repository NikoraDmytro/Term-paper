namespace DAL.DataTransferObjects;

public class HospitalUnitDto
{
    public string Name { get; set; } = String.Empty;
    public int WardsNumber { get; set; }
    public int WorkforceSize { get; set; }
}