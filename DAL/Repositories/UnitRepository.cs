using CORE.Models;
using DALAbstractions.IRepositories;

namespace DAL.Repositories
{
    public class UnitRepository : GenericRepository<HospitalUnit>, IUnitRepository
    {
        public UnitRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<HospitalUnit> GetAllUnits()
        {
            return FindAll().OrderBy(unit => unit.Name).ToList();
        }
    }
}