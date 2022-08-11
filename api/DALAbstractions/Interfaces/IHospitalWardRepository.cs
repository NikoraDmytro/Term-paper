using CORE.Models;
using Core.RequestFeatures;

namespace DALAbstractions.Interfaces
{
    public interface IHospitalWardRepository : IGenericRepository<HospitalWard>
    {
        Task<(int, List<int>)> GetAllWardsNumbersAsync(
            HospitalWardParameters parameters);
        Task<(int, List<HospitalWard>)> GetHospitalWardsAsync(
            HospitalWardParameters parameters);
        Task<HospitalWard?> GetHospitalWardAsync(int wardNumber);
        Task CreateHospitalWardAsync(HospitalWard hospitalWard);
    }
}