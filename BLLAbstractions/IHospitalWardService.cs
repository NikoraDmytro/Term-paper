using Core.DataTransferObjects.HospitalWard;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IHospitalWardService
    {
        Task<IEnumerable<HospitalWardDto>> GetAllWardsAsync(
            string unitName,
            HospitalWardParameters parameters);
        Task<HospitalWardDto> GetWardAsync(int wardNumber);
        Task<HospitalWardDto> OpenWardInHospitalUnit(
            string unitName,
            CreateHospitalWardDto hospitalWardDto);
        Task CloseWardAsync(int wardNumber);
    }
}