using Core.DataTransferObjects.Doctor;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync(
            DoctorParameters parameters);
        Task<DoctorDto> GetDoctorAsync(string fullName);
        Task<DoctorDto> HireDoctorAsync(CreateDoctorDto doctorToHireDto);
        Task FireDoctorAsync(string fullName);
        Task UpdateDoctorExperience(
            string doctorFullName,
            UpdateDoctorExperienceDto experienceDto);
    }
}