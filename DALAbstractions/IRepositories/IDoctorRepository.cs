using CORE.Models;

namespace DALAbstractions.IRepositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDoctors(string hospitalUnitName);
        Doctor? GetDoctor(string hospitalUnitName, string name, string surname);
    }
}