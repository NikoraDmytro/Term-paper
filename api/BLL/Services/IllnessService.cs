using System.Data;
using AutoMapper;
using BLLAbstractions.Interfaces;
using Core.DataTransferObjects.Illnesses;
using Core.Exceptions;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions.Interfaces;

namespace BLL.Services
{
    public class IllnessService : BaseService, IIllnessService
    {
        public IllnessService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<(int, IEnumerable<string>)> 
            GetAllIllnessesAsync(IllnessParameters parameters)
        {
            var (pagesQuantity, names) = await UnitOfWork
                .IllnessRepository
                .GetIllnessesNamesAsync(parameters);
            
            return (pagesQuantity, names);
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

        public async Task<IllnessDto> AddIllnessAsync(CreateIllnessDto illnessDto)
        {
            string unitName = illnessDto.HospitalUnitName ?? "";
            var unit = await UnitOfWork
                .HospitalUnitRepository
                .GetByIdAsync(unitName);
            
            if (unit == null)
            {
                throw new KeyNotFoundException(
                    $"У лікарні немає відділення з назвою {unitName}");
            }

            var illness = await UnitOfWork
                .IllnessRepository
                .GetIllnessAsync(illnessDto.Name ?? "");

            if (illness != null)
            {
                throw new DuplicateNameException(
                    $"{illness.Name} вже у базі даних!");
            }
            
            var illnessToAdd = Mapper.Map<Illness>(illnessDto);
            
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

            var addedIllness = Mapper.Map<IllnessDto>(illnessToAdd);
            
            return addedIllness;
        }

        public async Task<IllnessDto> EditIllnessAsync(
            string name, CreateIllnessDto newIllnessDto)
        {
            await RemoveIllnessAsync(name);
            var editedIllness = await AddIllnessAsync(newIllnessDto);

            return editedIllness;
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