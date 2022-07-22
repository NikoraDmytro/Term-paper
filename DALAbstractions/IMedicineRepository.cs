using CORE.Models;
using Core.RequestFeatures;

namespace DALAbstractions;

public interface IMedicineRepository: IGenericRepository<Medicine>
{
    Task<List<Medicine>> GetMedicinesAsync(
        MedicineParameters parameters);
    void UpdateStock(IEnumerable<Medicine> medicines);
    Task<List<Medicine>> GetByNamesAsync(string[] names);
}