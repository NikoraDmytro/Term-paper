using CORE.Models;

namespace DALAbstractions
{
    public interface IHospitalUnitRepository : IGenericRepository<HospitalUnit>
    {
        Task<List<HospitalUnit>> GetAllUnitsAsync();
        Task<HospitalUnit?> GetUnitAsync(string name);
    }
}