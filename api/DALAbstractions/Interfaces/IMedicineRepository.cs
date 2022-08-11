using CORE.Models;
using Core.RequestFeatures;

namespace DALAbstractions.Interfaces;

public interface IMedicineRepository: IGenericRepository<Medicine>
{
    Task<(int, List<Medicine>)> GetMedicinesAsync(
        MedicineParameters parameters);
    void UpdateStock(IEnumerable<Medicine> medicines);
    Task<List<Medicine>> GetByNamesAsync(string[] names);
}