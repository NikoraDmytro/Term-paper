using Core.DataTransferObjects.Patient;
using Core.RequestFeatures;

namespace BLLAbstractions;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAllPatientsAsync(
        PagingParameters parameters);
    Task<PatientDto> GetPatientAsync(string fullName);
    Task<PatientDto> RegisterPatientAsync(CreatePatientDto patientToRegister);
    Task DischargePatientAsync(string fullName);
}