using CORE.Models;

namespace DALAbstractions.IRepositories
{
    public interface IUnitRepository
    {
        public IEnumerable<HospitalUnit> GetAllUnits();
        public HospitalUnit? GetUnit(string name);
    }
}