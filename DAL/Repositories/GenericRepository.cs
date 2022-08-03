using System.Linq.Expressions;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class GenericRepository<TEntity> 
        : IGenericRepository<TEntity> where TEntity: class 
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly HospitalContext Context;

        protected GenericRepository(HospitalContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        
        public virtual async Task<List<TEntity>> GetAsync(
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

        public async Task<(int, List<TEntity>)> GetPagedAsync(
            int pageNumber = 1,
            int pageSize = 5,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            
            if (filter != null)
            {
                query = filter(query);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            int total = query.Count();
            int pagesQuantity = total / pageSize + (total % pageSize != 0 ? 1: 0);
            
            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            
            foreach (var property in includeProperties.Split
                         (',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            var entities = await query.ToListAsync();
            
            return (pagesQuantity, entities);
        }


        public virtual async Task<TEntity?> GetByIdAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);

            return entity;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task DeleteByIdAsync(object id)
        {
            var entityToDelete = await DbSet.FindAsync(id);

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
            DbSet.Update(entityToUpdate);
        }
    }
}