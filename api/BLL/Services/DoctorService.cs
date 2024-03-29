using System.Data;
using AutoMapper;
using AutoMapper.Internal;
using BLLAbstractions.Interfaces;
using Core.DataTransferObjects.Doctor;
using Core.Exceptions;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions.Interfaces;

namespace BLL.Services
{
    public class DoctorService : BaseService, IDoctorService
    {
        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }
        
        public async Task<(int, IEnumerable<DoctorDto>)> GetAllDoctorsAsync(
            DoctorParameters parameters)
        {
            var (pagesQuantity, doctors) = await UnitOfWork
                .DoctorRepository
                .GetDoctorsAsync(parameters);
            
            var doctorsDto = Mapper.Map<IEnumerable<DoctorDto>>(doctors);
            
            return (pagesQuantity, doctorsDto);
        }

        public async Task<SingleDoctorDto> GetDoctorAsync(string fullName)
        {
            var doctor = await UnitOfWork
                .DoctorRepository
                .GetDoctorAsync(fullName);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Лікаря з ФІО {fullName} не знайдено!");
            }
            
            var doctorDto = Mapper.Map<SingleDoctorDto>(doctor);
            
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
            var doctor = await GetDoctorAsync(fullName);

            if (doctor.Patients.Count != 0)
            {
                throw new AppException($"Не можна звільнити лікаря! Він лікує {doctor.Patients.Count} пацієнтів!");
            }
            
            await UnitOfWork
                .DoctorRepository
                .DeleteDoctorAsync(fullName);
            
            await UnitOfWork.SaveAsync();
        }
    }
}