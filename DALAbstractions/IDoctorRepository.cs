using CORE.Models;

namespace DALAbstractions
{
    public interface IDoctorRepository : IPersonRepository<Doctor>
    {
        public Task DeleteDoctorAsync(string fullName);
        public Task<Doctor?> GetDoctorAsync(string fullName);
        public Task<IEnumerable<Doctor>> GetDoctorsAsync(
            int pageNumber, 
            int pageSize,
            string profession);
    }
}