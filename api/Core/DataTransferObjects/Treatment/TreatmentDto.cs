namespace Core.DataTransferObjects.Treatment;

public class TreatmentDto
{
    public byte Quantity { get; set; }
    public string DosageForm { get; set; } = String.Empty;
    public string MedicineName { get; set; } = String.Empty;
    public string UnitOfMeasure { get; set; } = String.Empty;
}