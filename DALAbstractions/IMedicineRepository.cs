using CORE.Models;

namespace DALAbstractions;

public interface IMedicineRepository: IGenericRepository<Medicine>
{
    Task<IEnumerable<Medicine>> GetMedicinesAsync(
        int pageNumber, 
        int pageSize);
    void UpdateStock(IEnumerable<Medicine> medicines);
    Task<Medicine[]> GetByNamesAsync(string[] names);
}