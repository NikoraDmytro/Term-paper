using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;
using DALAbstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class IllnessRepository : GenericRepository<Illness>, IIllnessRepository
    {
        public IllnessRepository(HospitalContext context) : base(context)
        {
        }

        public async Task<(int, string[])>
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

            if (!string.IsNullOrEmpty(parameters.SearchTerm))
            {
                query = query.Where(
                    name => name.Contains(parameters.SearchTerm));
            }

            query = (parameters.OrderBy.EndsWith("desc")
                    ? query.OrderByDescending(name => name)
                    : query.OrderBy(name => name));

            int pageSize = parameters.PageSize;
            int total = query.Count();
            int pagesQuantity = total / pageSize + (total % pageSize != 0 ? 1 : 0);

            string[] names = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToArrayAsync();

            return (pagesQuantity, names);
        }


        public async Task<Illness?> GetIllnessAsync(string name)
        {
            var illness = await DbSet
                .SingleOrDefaultAsync(illness => illness.Name == name);

            if (illness == null)
                return illness;

            illness.Treatments = await Context
                .Set<Treatment>()
                .Where(treatment => treatment.IllnessName == illness.Name)
                .Include(treatment => treatment.Medicine)
                .ToListAsync();

            return illness;
        }
    }
}