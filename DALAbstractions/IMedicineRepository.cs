using CORE.Models;

namespace DALAbstractions;

public interface IMedicineRepository: IGenericRepository<Medicine>
{
    Task<List<Medicine>> GetMedicinesAsync(
        int pageNumber, 
        int pageSize);
    void UpdateStock(IEnumerable<Medicine> medicines);
    Task<List<Medicine>> GetByNamesAsync(string[] names);
}