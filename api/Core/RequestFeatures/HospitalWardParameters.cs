namespace Core.RequestFeatures;

public class HospitalWardParameters: PagingParameters
{
    public string HospitalUnit { get; set; } = String.Empty;
    public short MinBedsQuantity { get; set; } = 0;
    public short MaxBedsQuantity { get; set; } = short.MaxValue;

    public bool ValidQuantityRange => MaxBedsQuantity > MinBedsQuantity;
}