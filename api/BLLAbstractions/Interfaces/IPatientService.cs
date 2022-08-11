using Core.DataTransferObjects.Patient;
using Core.RequestFeatures;

namespace BLLAbstractions.Interfaces;

public interface IPatientService
{
    Task<(int, IEnumerable<PatientDto>)> GetAllPatientsAsync(
        PatientParameters parameters);
    Task<PatientDto> GetPatientAsync(string fullName);
    Task<PatientDto> RegisterPatientAsync(CreatePatientDto patientToRegister);
    Task DischargePatientAsync(string fullName);
}