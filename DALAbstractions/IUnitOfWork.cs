namespace DALAbstractions
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Dispose();
    }
}