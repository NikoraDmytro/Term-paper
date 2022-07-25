using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;

namespace DAL.Repositories;

public class MedicineRepository: GenericRepository<Medicine>, IMedicineRepository
{
    public MedicineRepository(HospitalContext context) : base(context)
    {
    }
    
    private Func<IQueryable<Medicine>, IQueryable<Medicine>> 
        Filter(MedicineParameters parameters) => (query) =>
        {
            if (parameters.ValidQuantityRange)
            {
                query = query.Where(m => 
                    m.QuantityInStock >= parameters.MinQuantity &&
                    m.QuantityInStock <= parameters.MaxQuantity);
            }

            if (!string.IsNullOrEmpty(parameters.SearchTerm))
            {
                query = query.Where(m => 
                    m.Name.Contains(parameters.SearchTerm));
            }

            return query;
        };
    
    private Func<IQueryable<Medicine>, IOrderedQueryable<Medicine>> 
        OrderBy(string orderBy) => (query) => 
        { 
            string param = orderBy.Split(" ")[0];
            bool isDescending = orderBy.EndsWith("desc");

            IOrderedQueryable<Medicine> orderedQuery;
            
            switch (param)
            {
                case "name":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(m=> m.Name) : 
                        query.OrderBy(m=> m.Name);
                    break;
                case "quantity":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(m=> m.QuantityInStock):
                        query.OrderBy(m=> m.QuantityInStock);
                    break;
                default:
                    goto case "name";
            }
            
            return orderedQuery;
        };

    public async Task<List<Medicine>> GetMedicinesAsync(
        MedicineParameters parameters)
    {
        var medicines = await GetPagedAsync(
            parameters.PageNumber,
            parameters.PageSize,
            Filter(parameters),
            OrderBy(parameters.OrderBy));

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
            
            throw new KeyNotFoundException(
                $"{allMismatched} не знайдено у базі даних");
        }

        return medicines;
    }
}