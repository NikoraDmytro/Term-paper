using Core.DataTransferObjects.Medicine;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineDto>> GetAllAsync(
            PagingParameters parameters);
        Task DeleteMedicineAsync(string name);
        Task<MedicineDto> AddNewMedicineAsync(MedicineDto medicine);
        Task ResupplyMedicinesAsync(IEnumerable<MedicineDto> medicines);
        Task WriteOffMedicinesAsync(IEnumerable<MedicineDto> medicines);
    }
}