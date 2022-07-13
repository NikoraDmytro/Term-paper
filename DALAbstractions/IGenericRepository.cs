using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DALAbstractions
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
        Task<TEntity?> GetByKeyAsync(params object?[] key);
        Task InsertAsync(TEntity entity);
        Task DeleteByKeyAsync(params object?[] key);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}