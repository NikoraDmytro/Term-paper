using DALAbstractions.IRepositories;

namespace DALAbstractions;

public interface IUnitOfWork
{
    IDoctorRepository Doctor { get; }
    IUnitRepository HospitalUnit { get; }
    void Save();
}