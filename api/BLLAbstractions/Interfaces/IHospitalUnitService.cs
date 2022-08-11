using Core.DataTransferObjects.Doctor;
using Core.DataTransferObjects.HospitalUnit;
using Core.RequestFeatures;

namespace BLLAbstractions.Interfaces
{
    public interface IHospitalUnitService
    {
        Task<(int, List<DoctorDto>)> GetDoctorsAsync(
            string unitName,
            DoctorParameters parameters);
        Task<HospitalUnitDto> GetUnitAsync(string name);
        Task<IEnumerable<HospitalUnitDto>> GetAllUnitsAsync();
    }
}