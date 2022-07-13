using CORE.Models;
using DALAbstractions;

namespace DAL.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context)
            : base(context)
        {
        }
    }
}