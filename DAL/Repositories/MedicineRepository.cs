using Core.Exceptions;
using CORE.Models;
using DALAbstractions;

namespace DAL.Repositories;

public class MedicineRepository: GenericRepository<Medicine>, IMedicineRepository
{
    public MedicineRepository(HospitalContext context) : base(context)
    {
    }

    public async Task<List<Medicine>> GetMedicinesAsync(
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

    public async Task<List<Medicine>> GetByNamesAsync(string[] names)
    {
        var medicines = await GetAsync(
            medicine => names.Contains(medicine.Name));

        var matchedNames = medicines.Select(m => m.Name);
        var mismatchedNames = names.Except(matchedNames).ToArray();

        if (mismatchedNames.Length != 0)
        {
            string allMismatched = string.Join(",", mismatchedNames);
            
            throw new AppException(
                $"{allMismatched} не знайдено у базі даних");
        }

        return medicines;
    }
}