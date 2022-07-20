using CORE.Models;

namespace DALAbstractions
{
    public interface IPatientRepository : IPersonRepository<Patient>
    {
        public Task DeletePatientAsync(string fullName);
        public Task<Patient?> GetPatientAsync(string fullName);
        public Task<IEnumerable<Patient>> GetPatientsAsync(
            int pageNumber, 
            int pageSize);
    }
}