using DALAbstractions;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalContext _context;
        private DoctorRepository? _doctorRepository;

        public UnitOfWork(HospitalContext context)
        {
            _context = context;
        }

        public IDoctorRepository DoctorRepository =>
            _doctorRepository ??= new DoctorRepository(_context);
        
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