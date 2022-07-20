using CORE.Models;

namespace DALAbstractions
{
    public interface IHospitalWardRepository : IGenericRepository<HospitalWard>
    {
        Task<IEnumerable<HospitalWard>> GetHospitalWardsAsync(
            int pageNumber,
            int pageSize);
        Task CreateHospitalWardAsync(HospitalWard hospitalWard);
    }
}