using CORE.Models;
using DALAbstractions;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalContext _context;
        
        private GenericRepository<Doctor>? _doctorRepository;
        private GenericRepository<HospitalUnit>? _unitRepository;

        public UnitOfWork(HospitalContext context)
        {
            _context = context;
        }

        public GenericRepository<HospitalUnit> HospitalUnit => 
            _unitRepository ??= new GenericRepository<HospitalUnit>(_context);
        public GenericRepository<Doctor> Doctor => 
            _doctorRepository ??= new GenericRepository<Doctor>(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        
        private bool _disposed = false;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}