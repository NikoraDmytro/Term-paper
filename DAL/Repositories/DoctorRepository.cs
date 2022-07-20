using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;

namespace DAL.Repositories
{
    public class DoctorRepository : PersonRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context)
            : base(context)
        {
        }

        public async Task<Doctor?> GetDoctorAsync(string fullName)
        {
            var doctor = await GetByNameAsync(
                fullName,
                "HospitalUnit");

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(DoctorParameters parameters)
        {
            var doctors = await GetPagedAsync(
                parameters.PageNumber,
                parameters.PageSize,
                DbSet.Where(NameFilter(parameters.SearchTerm)),
                parameters.HospitalUnit != "" ? 
                    doctor => 
                        doctor.HospitalUnitName == parameters.HospitalUnit 
                    : null,
                includeProperties: "HospitalUnit");
            
            return doctors;
        }

        public async Task DeleteDoctorAsync(string fullName)
        {
            await DeleteByNameAsync(fullName);
        }
    }
}