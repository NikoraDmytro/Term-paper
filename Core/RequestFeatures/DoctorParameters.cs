namespace Core.RequestFeatures;

public class DoctorParameters: PagingParameters
{
   public string HospitalUnit { get; set; } = String.Empty;
}