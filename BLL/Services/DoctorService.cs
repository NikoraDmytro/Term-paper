using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects;
using Core.Exceptions;
using CORE.Models;
using DALAbstractions;

namespace BLL.Services
{
    public class DoctorService : BaseService, IDoctorService
    {
        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await UnitOfWork.DoctorRepository.GetAsync(includeProperties: "HospitalUnit");
            
            var doctorsDto = Mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return doctorsDto;
        }

        public async Task<DoctorDto> GetDoctorAsync(string name, string surname, string patronymic)
        {
            var doctor = await UnitOfWork.DoctorRepository
                .GetByKeyAsync(surname, name, patronymic);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Доктор {surname} {name} {patronymic} не працює у цій лікарні!"
                    );
            }

            var doctorDto = Mapper.Map<DoctorDto>(doctor);

            return doctorDto;
        }

        public async Task<DoctorDto> HireDoctorAsync(CreateDoctorDto doctorToHireDto)
        {
            var doctorToHire = Mapper.Map<Doctor>(doctorToHireDto);
            
            await UnitOfWork.DoctorRepository.InsertAsync(doctorToHire);
            await UnitOfWork.SaveAsync();

            var hiredDoctor = Mapper.Map<DoctorDto>(doctorToHire);

            return hiredDoctor;
        }

        public async Task FireDoctorAsync(string name, string surname, string patronymic)
        {
            await UnitOfWork.DoctorRepository
                .DeleteByKeyAsync(surname, name, patronymic);
            await UnitOfWork.SaveAsync();
        }
    }
}