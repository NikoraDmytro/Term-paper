using System.Linq.Expressions;

using CORE.Models;
using DALAbstractions.IRepositories;

namespace DAL.Repositories;

public class DoctorRepository: GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(HospitalContext context): base(context)
    {
    }

    public IEnumerable<Doctor> GetAllDoctors()
    {
        return FindAll().OrderBy(doctor => doctor.Name).ToList();
    }
}