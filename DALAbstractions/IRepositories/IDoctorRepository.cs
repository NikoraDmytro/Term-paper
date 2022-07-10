using CORE.Models;

namespace DALAbstractions.IRepositories
{
    public interface IDoctorRepository
    {
        public IEnumerable<Doctor> GetDoctors(string hospitalUnitName);
        public Doctor? GetDoctor(string hospitalUnitName, string name, string surname);
    }
}