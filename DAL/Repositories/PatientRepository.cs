using CORE.Models;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PatientRepository: PersonRepository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalContext context) : base(context)
        {
        }

        public async Task DeletePatientAsync(string fullName)
        {
            await DeleteByFullNameAsync(fullName);
        }

        public async Task<Patient?> GetPatientAsync(string fullName)
        {
            var patient = await FindByFullNameAsync(fullName);

            return patient;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(
            int pageNumber = 1,
            int pageSize = 5)
        {
            var patients = await GetPagedAsync(pageNumber, pageSize);

            return patients;
        }
    }
}