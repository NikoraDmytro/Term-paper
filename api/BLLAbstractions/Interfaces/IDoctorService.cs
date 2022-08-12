using Core.DataTransferObjects.Doctor;
using Core.RequestFeatures;

namespace BLLAbstractions.Interfaces
{
    public interface IDoctorService
    {
        Task<(int, IEnumerable<DoctorDto>)> GetAllDoctorsAsync(
            DoctorParameters parameters);
        Task<SingleDoctorDto> GetDoctorAsync(string fullName);
        Task<DoctorDto> HireDoctorAsync(CreateDoctorDto doctorToHireDto);
        Task FireDoctorAsync(string fullName);
    }
}