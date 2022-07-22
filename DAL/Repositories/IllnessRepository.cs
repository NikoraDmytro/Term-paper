using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class IllnessRepository : GenericRepository<Illness>, IIllnessRepository
    {
        public IllnessRepository(HospitalContext context) : base(context)
        {
        }

        public async Task<string[]> 
            GetIllnessesNamesAsync(IllnessParameters parameters)
        {
            IQueryable<string> query;
            var unitFilter = parameters.HospitalUnit;

            if (!string.IsNullOrEmpty(unitFilter))
            {
                query = DbSet
                    .Where(illness => illness.HospitalUnitName == unitFilter)
                    .Select(illness => illness.Name ?? "");
            }
            else
            {
                query = DbSet.Select(illness => illness.Name ?? "");
            }

            query = (parameters.OrderBy.EndsWith("desc")
                    ? query.OrderByDescending(name => name)
                    : query.OrderBy(name => name))
                .Where(name => name.Contains(parameters.SearchTerm));

            string[] names = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToArrayAsync();
            
            return names;
        }

        public async Task<Illness?> GetIllnessAsync(string name)
        {
            var illness = await DbSet
                .Include(illness => illness.Treatments)
                .SingleOrDefaultAsync(illness => illness.Name == name);

            return illness;
        }
    }
}