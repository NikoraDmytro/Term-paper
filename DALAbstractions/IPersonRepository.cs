using System.Linq.Expressions;

namespace DALAbstractions
{
    public interface IPersonRepository<TPerson> : IGenericRepository<TPerson> where TPerson : class
    {
        Expression<Func<TPerson, bool>> NameFilter(string fullName);
        Task<TPerson?> GetByNameAsync(
            string fullName, 
            string includeProperties = "");
        Task DeleteByNameAsync(string fullName);
    }
}