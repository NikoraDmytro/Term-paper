using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects.Medicine;
using Core.Exceptions;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;

namespace BLL.Services
{
    public class MedicineService : BaseService, IMedicineService
    {
        public MedicineService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
        
        public async Task<IEnumerable<MedicineDto>> GetAllAsync(MedicineParameters parameters)
        {
            var medicines = await UnitOfWork
                .MedicineRepository
                .GetMedicinesAsync(parameters);

            var medicinesDto = Mapper.Map<IEnumerable<MedicineDto>>(medicines);
            
            return medicinesDto;
        }

        public async Task<MedicineDto> AddNewMedicineAsync(
            MedicineDto medicineDto)
        {
            var medicine = Mapper.Map<Medicine>(medicineDto);
            string medicineName = medicine.Name ?? string.Empty;
            
            var exists = await UnitOfWork.MedicineRepository
                .GetByIdAsync(medicineName);

            if (exists != null)
            {
                throw new AppException($"Ліки з назвою {medicineName} вже числяться на складі");
            }

            await UnitOfWork
                .MedicineRepository
                .InsertAsync(medicine);
            await UnitOfWork.SaveAsync();

            return medicineDto;
        }

        public async Task DeleteMedicineAsync(string medicineName)
        {
            var medicine = await UnitOfWork
                .MedicineRepository
                .GetByIdAsync(medicineName);

            if (medicine == null)
            {
                throw new AppException($"Ліки з назвою {medicineName} не числяться на складі");
            }

            await UnitOfWork
                .MedicineRepository
                .DeleteByIdAsync(medicineName);

            await UnitOfWork.SaveAsync();
        }

        private async Task UpdateStockAsync(
            MedicineDto[] medicinesDto,
            bool toResupply = true)
        {
            var medicinesNames = medicinesDto
                .Select(m => m.Name ?? "")
                .ToArray();
            
            var medicines = await UnitOfWork
                .MedicineRepository
                .GetByNamesAsync(medicinesNames);

            for (int i = 0; i < medicines.Count; i++)
            {
                if (toResupply)
                {
                    medicines[i].QuantityInStock +=
                        medicinesDto[i].Quantity ?? 0;
                }
                else
                {
                    medicines[i].QuantityInStock -=
                        medicinesDto[i].Quantity ?? 0;

                    if (medicines[i].QuantityInStock <= 0)
                    {
                        throw new AppException(
                            $"На складі немає потрібної кількості" +
                            medicines[i].Name +
                            $"\n\tЗалишилось: {medicines[i].QuantityInStock}" +
                            $"\n\tПотрібно: {medicinesDto[i].Quantity}");
                    }
                }
            }

            UnitOfWork
                .MedicineRepository
                .UpdateStock(medicines);
        }

        public async Task ResupplyMedicinesAsync(
            IEnumerable<MedicineDto> medicinesDto)
        {
            await UpdateStockAsync(medicinesDto.ToArray());
            await UnitOfWork.SaveAsync();
        }

        public async Task WriteOffMedicinesAsync(
            IEnumerable<MedicineDto> medicinesDto)
        {
            await UpdateStockAsync(medicinesDto.ToArray(), false);
            await UnitOfWork.SaveAsync();

        }

    }
}