using CORE.Models;
using DALAbstractions;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalContext _context;
        
        private IDoctorRepository? _doctorRepository;
        private IHospitalUnitRepository? _hospitalUnitRepository;
        private IHospitalWardRepository? _hospitalWardRepository;
        private IMedicineRepository? _medicineRepository;
        private IIllnessRepository? _illnessRepository;
        private IPatientRepository? _patientRepository;
        
        public UnitOfWork(HospitalContext context)
        {
            _context = context;
        }

        public IDoctorRepository DoctorRepository =>
            _doctorRepository ??= new DoctorRepository(_context);
        public IHospitalUnitRepository HospitalUnitRepository =>
            _hospitalUnitRepository ??= new HospitalUnitRepository(_context);
        public IHospitalWardRepository HospitalWardRepository =>
            _hospitalWardRepository ??= new HospitalWardRepository(_context);
        public IMedicineRepository MedicineRepository =>
            _medicineRepository ??= new MedicineRepository(_context);

        public IIllnessRepository IllnessRepository =>
            _illnessRepository ??= new IllnessRepository(_context);

        public IPatientRepository PatientRepository =>
            _patientRepository ??= new PatientRepository(_context);
        
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