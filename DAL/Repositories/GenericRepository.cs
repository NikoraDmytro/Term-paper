using System.Linq.Expressions;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class GenericRepository<TEntity> 
        : IGenericRepository<TEntity> where TEntity: class 
    {
        protected readonly HospitalContext _context;
        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepository(HospitalContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
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

        public async Task<IEnumerable<TEntity>> GetPagedAsync(
            int pageNumber = 1,
            int pageSize = 5,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            
            foreach (var property in includeProperties.Split
                         (',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            var entities = await (orderBy != null ? orderBy(query) : query)
                .ToListAsync();
            
            return entities;
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