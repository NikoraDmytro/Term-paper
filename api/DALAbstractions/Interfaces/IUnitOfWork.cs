namespace DALAbstractions.Interfaces
{
    public interface IUnitOfWork
    {
        IDoctorRepository DoctorRepository { get; }
        IHospitalUnitRepository HospitalUnitRepository { get; }
        IHospitalWardRepository HospitalWardRepository { get; }
        IMedicineRepository MedicineRepository { get; }
        IIllnessRepository IllnessRepository { get; }
        IPatientRepository PatientRepository { get; }
        
        Task SaveAsync();
        void Dispose();
    }
}