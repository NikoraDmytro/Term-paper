using CORE.Models;
using DALAbstractions.IRepositories;

namespace DAL.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<Doctor> GetDoctors(string unitName)
        {
            return FindByCondition(d => d.HospitalUnitName == unitName).OrderBy(d => d.Name).ToList();
        }

        public Doctor? GetDoctor(string unitName, string name, string surname)
        {
            return FindByCondition(d => 
                       d.Name.Equals(name) &&
                       d.Surname.Equals(surname) &&
                       d.HospitalUnitName.Equals(unitName))
                .SingleOrDefault();
        }
    }
}