using System.Data;
using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects.Doctor;
using Core.Exceptions;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;

namespace BLL.Services
{
    public class DoctorService : BaseService, IDoctorService
    {
        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }
        
        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync(
            DoctorParameters parameters)
        {
            var doctors = await UnitOfWork
                .DoctorRepository
                .GetDoctorsAsync(parameters);
            
            var doctorsDto = Mapper.Map<IEnumerable<DoctorDto>>(doctors);
            
            return doctorsDto;
        }

        public async Task<DoctorDto> GetDoctorAsync(string fullName)
        {
            var doctor = await UnitOfWork
                .DoctorRepository
                .GetDoctorAsync(fullName);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Лікаря з ФІО {fullName} не знайдено!"
                    );
            }
            
            var doctorDto = Mapper.Map<DoctorDto>(doctor);
            
            return doctorDto;
        }

        public async Task<DoctorDto> HireDoctorAsync(CreateDoctorDto doctorToHireDto)
        {
            string unitName = doctorToHireDto.HospitalUnitName;
            
            var unit = await UnitOfWork
                .HospitalUnitRepository
                .GetByIdAsync(unitName);
            
            if (unit == null)
            {
                throw new KeyNotFoundException(
                    $"У лікарні немає відділення з назвою {unitName}");
            }
            
            var doctorToHire = Mapper.Map<Doctor>(doctorToHireDto);
            doctorToHire.Profession = unit.Profession;
            
            string doctorFullName = doctorToHire.FullName;
            
            var doctor = await UnitOfWork
                .DoctorRepository
                .GetDoctorAsync(doctorFullName);

            if (doctor != null)
            {
                throw new DuplicateNameException(
                    $"{doctorFullName} вже працює у лікарні!"
                );
            }
            
            await UnitOfWork
                .DoctorRepository
                .InsertAsync(doctorToHire);
            await UnitOfWork.SaveAsync();

            var hiredDoctor = Mapper.Map<DoctorDto>(doctorToHire);
            
            return hiredDoctor;
        }

        public async Task FireDoctorAsync(string fullName)
        {
            //will throw error if doctor not exist
            await GetDoctorAsync(fullName);
            
            await UnitOfWork
                .DoctorRepository
                .DeleteDoctorAsync(fullName);
            
            await UnitOfWork.SaveAsync();
        }

        public async Task UpdateDoctorExperience(
            string doctorFullName,
            UpdateDoctorExperienceDto experienceDto)
        {
            var doctor = await UnitOfWork
                .DoctorRepository
                .GetDoctorAsync(doctorFullName);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Лікаря з ФІО {doctorFullName} не знайдено!"
                );
            }
            
            doctor.Experience = experienceDto.Experience ?? 0;

            UnitOfWork.DoctorRepository.Update(doctor);
            await UnitOfWork.SaveAsync();
        }
    }
}