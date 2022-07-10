using CORE.Models;

namespace DALAbstractions.IRepositories
{
    public interface IDoctorRepository
    {
        public IEnumerable<Doctor> GetAllDoctors();
    }
}