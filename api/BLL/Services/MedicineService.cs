using System.Data;
using AutoMapper;
using BLLAbstractions;
using BLLAbstractions.Interfaces;
using Core.DataTransferObjects.Medicine;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions.Interfaces;

namespace BLL.Services
{
    public class MedicineService : BaseService, IMedicineService
    {
        public MedicineService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
        
        public async Task<(int, IEnumerable<MedicineDto>)> GetAllAsync(MedicineParameters parameters)
        {
            var (pagesQuantity, medicines) = await UnitOfWork
                .MedicineRepository
                .GetMedicinesAsync(parameters);

            var medicinesDto = Mapper.Map<IEnumerable<MedicineDto>>(medicines);
            
            return (pagesQuantity, medicinesDto);
        }

        public async Task<MedicineDto> AddNewMedicineAsync(
            CreateMedicineDto medicineDto)
        {
            string medicineName = medicineDto.Name ?? "";
            
            var exists = await UnitOfWork.MedicineRepository
                .GetByIdAsync(medicineName);

            if (exists != null)
            {
                throw new DuplicateNameException(
                    $"Ліки з назвою {medicineName} вже числяться на складі");
            }
            
            var medicine = Mapper.Map<Medicine>(medicineDto);

            await UnitOfWork
                .MedicineRepository
                .InsertAsync(medicine);
            await UnitOfWork.SaveAsync();

            var addedMedicineDto = Mapper.Map<MedicineDto>(medicine);
            
            return addedMedicineDto;
        }

        public async Task DeleteMedicineAsync(string medicineName)
        {
            var medicine = await UnitOfWork
                .MedicineRepository
                .GetByIdAsync(medicineName);

            if (medicine == null)
            {
                throw new KeyNotFoundException(
                    $"Ліки з назвою {medicineName} не числяться на складі");
            }

            await UnitOfWork
                .MedicineRepository
                .DeleteByIdAsync(medicineName);

            await UnitOfWork.SaveAsync();
        }

        public async Task ResupplyMedicinesAsync(
            List<UpdateMedicineDto> medicinesDto)
        {
            var medicinesNames = medicinesDto
                .Select(m => m.Name ?? "")
                .ToArray();
            
            var medicines = await UnitOfWork
                .MedicineRepository
                .GetByNamesAsync(medicinesNames);

            for (int i = 0; i < medicines.Count; i++)
            {
                medicines[i].QuantityInStock +=
                    medicinesDto[i].Quantity ?? 0;
            }

            UnitOfWork
                .MedicineRepository
                .UpdateStock(medicines);
            await UnitOfWork.SaveAsync();
        }
    }
}