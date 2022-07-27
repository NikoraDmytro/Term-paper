using System.Data;
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
        
        public async Task<(int, IEnumerable<PatientDto>)> 
            GetAllPatientsAsync(PatientParameters parameters)
        {
            var (pagesQuantity, patients) = await UnitOfWork
                .PatientRepository
                .GetPatientsAsync(parameters);

            var patientsDto = Mapper.Map<IEnumerable<PatientDto>>(patients);

            return (pagesQuantity, patientsDto);
        }

        public async Task<PatientDto> GetPatientAsync(string fullName)
        {
            var patient = await UnitOfWork
                .PatientRepository
                .GetPatientAsync(fullName);

            if (patient == null)
            {
                throw new KeyNotFoundException(
                    $"Пацієнта з ФІО {fullName} не знайдено!");
            }
            
            var patientDto = Mapper.Map<PatientDto>(patient);

            return patientDto;
        }

        public async Task<PatientDto> 
            RegisterPatientAsync(CreatePatientDto patientToRegisterDto)
        {
            int wardNumber = 
                patientToRegisterDto.HospitalWardNumber ?? 0;
            string illnessName = 
                patientToRegisterDto.Diagnosis ?? "";
            string doctorFullName = 
                patientToRegisterDto.AttendingDoctor ?? "";

            var diagnosis = await UnitOfWork
                .IllnessRepository
                .GetIllnessAsync(illnessName);

            if (diagnosis == null)
            {
                throw new KeyNotFoundException(
                    $"Хворобу з назвою {diagnosis} не знайдено в базі даних!");
            }

            var ward = await UnitOfWork
                .HospitalWardRepository
                .GetHospitalWardAsync(wardNumber);

            if (ward == null)
            {
                throw new KeyNotFoundException(
                    $"Палату №{wardNumber} не знайдено!");
            }
            if (diagnosis.HospitalUnitName != ward.HospitalUnitName)
            {
                throw new AppException(
                    $"{diagnosis.Name} не лікується у відділенні" +
                    $", де знаходиться палата №{wardNumber}!"
                );
            }
            if (ward.Occupancy == ward.BedsQuantity)
            {
                throw new AppException(
                    $"В палаті №{wardNumber} немає вільних ліжко-місць!");
            }

            var doctor = await UnitOfWork
                .DoctorRepository
                .GetDoctorAsync(doctorFullName);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Лікаря з ФІО {doctorFullName} не знайдено!"
                );
            }
            if (diagnosis.HospitalUnitName != doctor.HospitalUnitName)
            {
                throw new AppException(
                    $"{diagnosis.Name} не лікується у відділенні" +
                    $", де працює лікар {doctorFullName}!"
                );
            }

            await WriteOffMedicines(diagnosis);
            
            var patientToRegister = Mapper.Map<Patient>(patientToRegisterDto);
            
            string fullName = patientToRegister.FullName;

            var patient = await UnitOfWork
                .PatientRepository
                .GetPatientAsync(fullName);

            if (patient != null)
            {
                throw new DuplicateNameException(
                    $"{fullName} вже зареєстрований в лікарні!"
                );
            }
            
            await UnitOfWork
                .PatientRepository
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

        private async Task WriteOffMedicines(Illness diagnosis)
        {
            var medicinesNames = diagnosis
                .Treatments
                .Select(t => t.MedicineName ?? "")
                .ToArray();
            
            var medicines = await UnitOfWork
                .MedicineRepository
                .GetByNamesAsync(medicinesNames);

            for (int i = 0; i < medicines.Count; i++)
            {
                var quantity = diagnosis
                    .Treatments[i]
                    .MedicineQuantity;
                
                if (medicines[i].QuantityInStock - quantity <= 0)
                {
                    throw new AppException(
                        $"На складі немає потрібної кількості " +
                        $"{medicines[i].Name}: " +
                        $"Залишилось: {medicines[i].QuantityInStock}; " +
                        $"Потрібно: {quantity}");
                }
                
                medicines[i].QuantityInStock -= quantity;
            }

            UnitOfWork.MedicineRepository.UpdateStock(medicines);
        }
    }
}