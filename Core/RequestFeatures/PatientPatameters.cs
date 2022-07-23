namespace Core.RequestFeatures;

public class PatientParameters: PagingParameters
{
    public int HospitalWard { get; set; } = 0;
    public string Diagnosis { get; set; } = String.Empty;
    public string AttendingDoctor { get; set; } = String.Empty;
}