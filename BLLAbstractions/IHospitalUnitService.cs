using Core.DataTransferObjects.Doctor;
using Core.DataTransferObjects.HospitalUnit;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IHospitalUnitService
    {
        Task<List<DoctorDto>> GetDoctorsAsync(
            string unitName,
            DoctorParameters parameters);
        Task<HospitalUnitDto> GetUnitAsync(string name);
        Task<IEnumerable<HospitalUnitDto>> GetAllUnitsAsync();
    }
}