namespace Core.DataTransferObjects.Medicine;

public class MedicineDto
{
    public string Name { get; set; } = String.Empty;
    public string DosageForm { get; set; } = String.Empty;
    public string UnitOfMeasure { get; set; } = String.Empty;
    public short QuantityInStock { get; set; }
}