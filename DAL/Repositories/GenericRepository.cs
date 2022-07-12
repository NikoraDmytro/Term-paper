using System.Linq.Expressions;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> 
        : IGenericRepository<TEntity> where TEntity: class 
    {
        private readonly HospitalContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(HospitalContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            
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

        public async Task<TEntity?> GetByIdAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(object id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public void Delete(TEntity entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}