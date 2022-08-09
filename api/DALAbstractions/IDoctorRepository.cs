using CORE.Models;
using Core.RequestFeatures;

namespace DALAbstractions
{
    public interface IDoctorRepository : IPersonRepository<Doctor>
    {
        public Task DeleteDoctorAsync(string fullName);
        public Task<Doctor?> GetDoctorAsync(string fullName);
        public Task<(int, List<Doctor>)> GetDoctorsAsync(
            DoctorParameters parameters);
    }
}