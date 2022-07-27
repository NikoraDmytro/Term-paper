using Core.DataTransferObjects.Medicine;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IMedicineService
    {
        Task<(int, IEnumerable<MedicineDto>)> GetAllAsync(
            MedicineParameters parameters);
        Task DeleteMedicineAsync(string name);
        Task<MedicineDto> AddNewMedicineAsync(MedicineDto medicine);
        Task ResupplyMedicinesAsync(List<UpdateMedicineDto> medicines);
    }
}