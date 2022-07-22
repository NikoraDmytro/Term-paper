using CORE.Models;
using Core.RequestFeatures;

namespace DALAbstractions
{
    public interface IHospitalWardRepository : IGenericRepository<HospitalWard>
    {
        Task<IEnumerable<HospitalWard>> GetHospitalWardsAsync(
            string unitName,
            HospitalWardParameters parameters);
        Task<HospitalWard?> GetHospitalWardAsync(int wardNumber);
        Task CreateHospitalWardAsync(HospitalWard hospitalWard);
    }
}