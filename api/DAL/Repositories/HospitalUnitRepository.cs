using System.Linq.Expressions;
using CORE.Models;
using DALAbstractions;
using DALAbstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class HospitalUnitRepository:
        GenericRepository<HospitalUnit>, 
        IHospitalUnitRepository
    {
        public HospitalUnitRepository(HospitalContext context)
            : base(context)
        {
        }

        private Expression<Func<HospitalUnit, HospitalUnit>> SelectUnit()
            => unit => new HospitalUnit()
            {
                Name = unit.Name,
                Profession = unit.Profession,
                DoctorsQuantity = unit.Doctors.Count(),
                TotalOccupancy = unit.HospitalWards
                    .Sum(ward => ward.Patients.Count()),
                WardsQuantity = unit.HospitalWards.Count(),
            };
        
        public async Task<List<HospitalUnit>> GetAllUnitsAsync()
        {
            var units = await DbSet
                .Select(SelectUnit())
                .ToListAsync();

            return units;
        }

        public async Task<HospitalUnit?> GetUnitAsync(string name)
        {
            var unit = await DbSet
                .Where(unit => unit.Name == name)
                .Select(SelectUnit())
                .SingleOrDefaultAsync();

            return unit;
        }
    }
}