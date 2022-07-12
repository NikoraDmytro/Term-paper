using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DALAbstractions
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
            string includeProperties = "");
        Task<TEntity?> GetByIdAsync(object id);
        Task InsertAsync(TEntity entity);
        Task DeleteByIdAsync(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}