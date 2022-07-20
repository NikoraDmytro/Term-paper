using Core.DataTransferObjects.HospitalWard;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IHospitalWardService
    {
        Task<IEnumerable<HospitalWardDto>> GetAllWardsAsync(
            PagingParameters parameters);
        Task<HospitalWardDto> GetWardAsync(int wardNumber);
        Task<HospitalWardDto> OpenNewWardAsync(CreateHospitalWardDto hospitalWardDto);
        Task CloseWardAsync(int wardNumber);
    }
}