using Core.DataTransferObjects.Medicine;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineDto>> GetAllAsync(
            MedicineParameters parameters);
        Task DeleteMedicineAsync(string name);
        Task<MedicineDto> AddNewMedicineAsync(MedicineDto medicine);
        Task ResupplyMedicinesAsync(List<MedicineDto> medicines);
    }
}