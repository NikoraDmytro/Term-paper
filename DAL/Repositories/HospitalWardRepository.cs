using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class HospitalWardRepository: GenericRepository<HospitalWard>, IHospitalWardRepository
    {
        public HospitalWardRepository(HospitalContext context)
            : base(context)
        {
        }

        private Func<IQueryable<HospitalWard>, IQueryable<HospitalWard>> 
            Filter(string unitName, HospitalWardParameters parameters) =>
            (query) =>
            {
                query = query.Where(ward => 
                    ward.HospitalUnitName == unitName);
                
                if (parameters.ValidQuantityRange)
                {
                    query = query.Where(ward =>
                        ward.BedsQuantity >= parameters.MinBedsQuantity &&
                        ward.BedsQuantity <= parameters.MaxBedsQuantity);
                }

                query = query.Select(ward => new HospitalWard()
                {
                    Number = ward.Number,
                    BedsQuantity = ward.BedsQuantity,
                    Occupancy = ward.Patients.Count(),
                });

                return query;
            };

        private Func<IQueryable<HospitalWard>, IOrderedQueryable<HospitalWard>>
            OrderBy(string orderBy) => (query) =>
        {
            string? param = orderBy.Split(" ")[0];
            bool isDescending = orderBy.EndsWith("desc");

            IOrderedQueryable<HospitalWard> orderedQuery;
            
            switch (param)
            {
                case "number":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(ward => ward.Number) : 
                        query.OrderBy(ward => ward.Number);
                    break;
                case "bedsQuantity":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(ward => ward.BedsQuantity):
                        query.OrderBy(ward => ward.BedsQuantity);
                    break;
                case "occupancy": 
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(ward => ward.Occupancy):
                        query.OrderBy(ward => ward.Occupancy);
                    break;
                default:
                    goto case "number";
            }

            return orderedQuery;
        };

        public async Task<List<HospitalWard>> GetHospitalWardsAsync(
            string unitName, 
            HospitalWardParameters parameters)
        {
            var hospitalWards = await GetPagedAsync(
                parameters.PageNumber,
                parameters.PageSize,
                Filter(unitName, parameters),
                OrderBy(parameters.OrderBy));
            
            return hospitalWards;
        }

        public async Task<HospitalWard?> GetHospitalWardAsync(int wardNumber)
        {
            var hospitalWard = await DbSet
                .Where(ward => ward.Number == wardNumber)
                .Select(ward => new HospitalWard()
                {
                    Number = ward.Number,
                    BedsQuantity = ward.BedsQuantity,
                    Occupancy = ward.Patients.Count(),
                })
                .SingleOrDefaultAsync();
               
            return hospitalWard;
        }

        public async Task CreateHospitalWardAsync(HospitalWard hospitalWard)
        {
            var unitName = hospitalWard.HospitalUnitName;
            var unitWards = DbSet
                .Where(ward => ward.HospitalUnitName == unitName);

            int unitIndex = unitWards.First().Number / 100;
            
            int wardsNumber = await DbSet
                .Where(ward => ward.HospitalUnitName == unitName)
                .CountAsync();

            hospitalWard.Number = unitIndex  * 100 + (wardsNumber + 1);

            await DbSet.AddAsync(hospitalWard);
        }
    }
}