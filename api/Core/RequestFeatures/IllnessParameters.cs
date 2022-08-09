namespace Core.RequestFeatures;

public class IllnessParameters: PagingParameters
{
    public string HospitalUnit { get; set; } = String.Empty;
}