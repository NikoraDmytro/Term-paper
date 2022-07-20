using System.Linq.Expressions;
using CORE.Models;
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
            var doctor = await FindByFullNameAsync(fullName, "HospitalUnit");

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(
            int pageNumber = 1,
            int pageSize = 5,
            string hospitalUnit = "")
        {
            Expression<Func<Doctor, bool>>? filter = null;
            
            if (hospitalUnit != String.Empty)
            {
                filter = (doctor) => doctor.HospitalUnitName == hospitalUnit;
            }

            var doctors = await GetPagedAsync(
                pageNumber,
                pageSize,
                filter,
                includeProperties: "HospitalUnit");

            return doctors;
        }

        public async Task DeleteDoctorAsync(string fullName)
        {
            await DeleteByFullNameAsync(fullName);
        }

    }
}