using CORE.Models;
using DALAbstractions;

namespace DAL.Repositories;

public class MedicineRepository: GenericRepository<Medicine>, IMedicineRepository
{
    public MedicineRepository(HospitalContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Medicine>> GetMedicinesAsync(
        int pageNumber = 1,
        int pageSize = 5)
    {
        var medicines = await GetPagedAsync(
            pageNumber,
            pageSize,
            orderBy: query => query.OrderBy(m => m.Name));

        return medicines;
    }

    public void UpdateStock(IEnumerable<Medicine> medicines)
    {
        DbSet.UpdateRange(medicines);
    }

    public async Task<Medicine[]> GetByNamesAsync(string[] names)
    {
        var medicines = await GetAsync(
            medicine => names.Contains(medicine.Name),
            query => query.OrderBy(m => m.Name));

        return medicines.ToArray();
    }
}