using CORE.Models;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class IllnessRepository : GenericRepository<Illness>, IIllnessRepository
    {
        public IllnessRepository(HospitalContext context) : base(context)
        {
        }


        public async Task<string[]> GetIllnessesNamesAsync()
        {
            string[] names = await DbSet
                .Select(illness => illness.Name ?? "")
                .OrderBy(name => name)
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