namespace Core.RequestFeatures;

public class MedicineParameters: PagingParameters
{
    public short MinQuantity { get; set; } = 0;
    public short MaxQuantity { get; set; } = short.MaxValue;
    
    public bool ValidQuantityRange => MaxQuantity > MinQuantity;
}