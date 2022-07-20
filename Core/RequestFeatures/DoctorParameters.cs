namespace Core.RequestFeatures;

public class DoctorParameters: PersonParameters
{
   public string HospitalUnit { get; set; } = String.Empty;
}