using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects.Patient;
using Core.Exceptions;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;

namespace BLL.Services
{
    public class PatientService : BaseService, IPatientService
    {
        public PatientService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<PatientDto>> 
            GetAllPatientsAsync(PagingParameters parameters)
        {
            var patients = await UnitOfWork.PatientRepository
                .GetPatientsAsync(
                    parameters.PageNumber,
                    parameters.PageSize);

            var patientsDto = Mapper.Map<IEnumerable<PatientDto>>(patients);

            return patientsDto;
        }

        public async Task<PatientDto> GetPatientAsync(string fullName)
        {
            var patient = await UnitOfWork.PatientRepository
                .GetPatientAsync(fullName);

            if (patient == null)
            {
                throw new AppException(
                    $"Пацієнта з ФІО {fullName} не знайдено!");
            }
            
            var patientDto = Mapper.Map<PatientDto>(patient);

            return patientDto;
        }

        public async Task<PatientDto> 
            RegisterPatientAsync(CreatePatientDto patientToRegisterDto)
        {
            int wardNumber = patientToRegisterDto.HospitalWardNumber ?? 0;
            string illnessName = patientToRegisterDto.IllnessName ?? "";
            string doctorFullName = patientToRegisterDto.AttendingDoctorFullName 
                                 ?? "";
            
            var ward = await UnitOfWork.HospitalWardRepository
                .GetByIdAsync(wardNumber);

            if (ward == null)
            {
                throw new AppException(
                    $"Палату {wardNumber} з номером не знайдено!");
            }

            var diagnosis = await UnitOfWork.IllnessRepository
                .GetIllnessAsync(illnessName);

            if (diagnosis == null)
            {
                throw new AppException(
                    $"Хворобу з назвою {diagnosis} не знайдено в базі даних!");
            }

            var doctor = await UnitOfWork.DoctorRepository
                .GetDoctorAsync(doctorFullName);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Лікаря з ФІО {doctorFullName} не знайдено!"
                );
            }

            var patientToRegister = Mapper.Map<Patient>(patientToRegisterDto);

            string fullName = patientToRegister.FullName;

            var patient = await UnitOfWork.PatientRepository
                .GetPatientAsync(fullName);

            if (patient != null)
            {
                throw new AppException(
                    $"{fullName} вже зареєстрований в лікарні!"
                );
            }
            
            patientToRegister.Diagnosis = diagnosis;
            patientToRegister.AttendingDoctor = doctor;

            await UnitOfWork.PatientRepository
                .InsertAsync(patientToRegister);
            await UnitOfWork.SaveAsync();

            var registeredPatient = Mapper.Map<PatientDto>(patientToRegister);

            return registeredPatient;
        }

        public async Task DischargePatientAsync(string fullName)
        {
            //will throw error if doctor not exist
            await GetPatientAsync(fullName);
            
            await UnitOfWork.PatientRepository
                .DeletePatientAsync(fullName);
            
            await UnitOfWork.SaveAsync();
        }
    }
}