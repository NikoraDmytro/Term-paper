using System.Linq.Expressions;
using CORE.Models;

namespace DALAbstractions;

public interface IPersonRepository<TPerson>: IGenericRepository<TPerson> where TPerson: class
{
    public Task<TPerson?> FindByFullNameAsync(string fullName, string includeProperties = "");
    public Task DeleteByFullNameAsync(string fullName);
}