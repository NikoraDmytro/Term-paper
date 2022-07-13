namespace DALAbstractions
{
    public interface IUnitOfWork
    {
        IDoctorRepository DoctorRepository { get; }
        
        Task SaveAsync();
        void Dispose();
    }
}