using Core.DataTransferObjects.Medicine;
using Core.RequestFeatures;

namespace BLLAbstractions.Interfaces
{
    public interface IMedicineService
    {
        Task<(int, IEnumerable<MedicineDto>)> GetAllAsync(
            MedicineParameters parameters);
        Task DeleteMedicineAsync(string name);
        Task<MedicineDto> AddNewMedicineAsync(CreateMedicineDto medicine);
        Task ResupplyMedicinesAsync(List<UpdateMedicineDto> medicines);
    }
}