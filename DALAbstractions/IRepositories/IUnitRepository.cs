using CORE.Models;

namespace DALAbstractions.IRepositories
{
    public interface IUnitRepository
    {
        IEnumerable<HospitalUnit> GetAllUnits();
        HospitalUnit? GetUnit(string name);
        void CreateUnit(HospitalUnit hospitalUnit);
    }
}