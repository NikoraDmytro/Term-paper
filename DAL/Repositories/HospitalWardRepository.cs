using CORE.Models;
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

        public async Task<IEnumerable<HospitalWard>> GetHospitalWardsAsync(
            int pageNumber = 1,
            int pageSize = 5)
        {
            var hospitalWards = await GetPagedAsync(
                pageNumber,
                pageSize,
                includeProperties: "Patients");

            return hospitalWards;
        }

        public async Task CreateHospitalWardAsync(HospitalWard hospitalWard)
        {
            var units = await _context.Set<HospitalUnit>().ToListAsync();

            var wardsNumber = await DbSet.Where(ward => 
                    ward.HospitalUnitName == hospitalWard.HospitalUnitName)
                .CountAsync();
            var hospitalUnitIndex = units.FindIndex(
                unit => unit.Name == hospitalWard.HospitalUnitName);

            hospitalWard.Number = hospitalUnitIndex * 100 + (wardsNumber + 1);

            await DbSet.AddAsync(hospitalWard);
        }
    }
}