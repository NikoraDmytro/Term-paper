using Core.DataTransferObjects;
using CORE.Models;

namespace BLLAbstractions;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
    Task<DoctorDto> GetDoctorAsync(string name, string surname, string patronymic);
    Task<DoctorDto> HireDoctorAsync(CreateDoctorDto doctorToHire);
    Task FireDoctorAsync(string name, string surname, string patronymic);
}