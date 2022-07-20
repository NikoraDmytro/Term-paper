using Core.DataTransferObjects.HospitalUnit;

namespace BLLAbstractions
{
    public interface IHospitalUnitService
    {
        Task<HospitalUnitDto> GetUnitAsync(string name);
        Task<IEnumerable<HospitalUnitDto>> GetAllUnitsAsync();
    }
}