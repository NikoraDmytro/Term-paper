using Core.DataTransferObjects.HospitalWard;
using Core.DataTransferObjects.Patient;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IHospitalWardService
    {
        Task<(int, IEnumerable<HospitalWardDto>)> GetAllWardsAsync(
            string unitName,
            HospitalWardParameters parameters);
        Task<HospitalWardDto> GetWardAsync(
            string unitName,
            int wardNumber);
        Task<HospitalWardDto> OpenWardInHospitalUnit(
            string unitName,
            CreateHospitalWardDto hospitalWardDto);
        Task CloseWardAsync(
            string unitName,
            int wardNumber);
        Task<(int, List<PatientDto>)> GetPatientsAsync(
            string unitName,
            int wardNumber,
            PatientParameters parameters);
    }
}