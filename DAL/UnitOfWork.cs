using DAL.Repositories;
using DALAbstractions;
using DALAbstractions.IRepositories;

namespace DAL;

public class UnitOfWork: IUnitOfWork
{
    private HospitalContext _context;
    private IUnitRepository? _unitRepository;
    private IDoctorRepository? _doctorRepository;

    public UnitOfWork(HospitalContext context)
    {
        _context = context;
    }

    public IUnitRepository HospitalUnit  => _unitRepository ??= new UnitRepository(_context);

    public IDoctorRepository Doctor => _doctorRepository ??= new DoctorRepository(_context);

    public void Save() => _context.SaveChanges();
}