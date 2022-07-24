using System.Data;
using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects.Illnesses;
using Core.Exceptions;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;

namespace BLL.Services
{
    public class IllnessService : BaseService, IIllnessService
    {
        public IllnessService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<string>> 
            GetAllIllnessesAsync(IllnessParameters parameters)
        {
            string[] names = await UnitOfWork
                .IllnessRepository
                .GetIllnessesNamesAsync(parameters);
            
            return names;
        }

        public async Task<IllnessDto> GetIllnessAsync(string name)
        {
            var illness = await UnitOfWork
                .IllnessRepository
                .GetIllnessAsync(name);

            if (illness == null)
            {
                throw new AppException($"Хвороби з назвою {name} не існує!");
            }

            var illnessDto = Mapper.Map<IllnessDto>(illness);

            return illnessDto;
        }

        public async Task<IllnessDto> AddIllnessAsync(IllnessDto illnessDto)
        {
            string unitName = illnessDto.HospitalUnitName;
            var unit = await UnitOfWork
                .HospitalUnitRepository
                .GetByIdAsync(unitName);
            
            if (unit == null)
            {
                throw new KeyNotFoundException(
                    $"У лікарні немає відділення з назвою {unitName}");
            }
            
            var illnessToAdd = Mapper.Map<Illness>(illnessDto);
            
            var illness = await UnitOfWork
                .IllnessRepository
                .GetIllnessAsync(illnessDto.Name);

            if (illness != null)
            {
                throw new DuplicateNameException(
                    $"{illness.Name} вже у базі даних!");
            }

            var medicinesNames = illnessToAdd
                .Treatments
                .Select(t => t.MedicineName ?? "")
                .ToArray();

            //Throws an error if the medicines provided are not in DB 
            await UnitOfWork
                .MedicineRepository
                .GetByNamesAsync(medicinesNames);
            
            await UnitOfWork
                .IllnessRepository
                .InsertAsync(illnessToAdd);
            await UnitOfWork.SaveAsync();
            
            return illnessDto;
        }

        public async Task RemoveIllnessAsync(string name)
        {
            //will throw error if doctor not exist
            await GetIllnessAsync(name);

            await UnitOfWork
                .IllnessRepository
                .DeleteByIdAsync(name);

            await UnitOfWork.SaveAsync();
        }
    }
}