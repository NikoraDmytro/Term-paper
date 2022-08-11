using System.Linq.Expressions;

namespace DALAbstractions.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
        Task<(int, List<TEntity>)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = ""
        );
        Task<TEntity?> GetByIdAsync(object id);
        Task InsertAsync(TEntity entity);
        Task DeleteByIdAsync(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}