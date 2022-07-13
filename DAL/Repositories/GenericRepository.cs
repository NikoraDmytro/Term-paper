using System.Linq.Expressions;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class GenericRepository<TEntity> 
        : IGenericRepository<TEntity> where TEntity: class 
    {
        protected readonly HospitalContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepository(HospitalContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        
        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var property in includeProperties.Split
                         (',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            var entities = await (orderBy != null ? orderBy(query) : query)
                .ToListAsync();
            
            return entities;
        }

        public virtual async Task<TEntity?> GetByKeyAsync(params object?[] key)
        {
            var entity = await DbSet.FindAsync(key);

            return entity;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task DeleteByKeyAsync(params object?[] key)
        {
            var entityToDelete = await DbSet.FindAsync(key);

            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}