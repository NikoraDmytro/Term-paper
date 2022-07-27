using CORE.Models;
using Core.RequestFeatures;

namespace DALAbstractions
{
    public interface IPatientRepository : IPersonRepository<Patient>
    {
        public Task DeletePatientAsync(string fullName);
        public Task<Patient?> GetPatientAsync(string fullName);
        public Task<(int, List<Patient>)> GetPatientsAsync(
            PatientParameters parameters);
    }
}