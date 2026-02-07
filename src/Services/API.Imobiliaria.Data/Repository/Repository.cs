using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Imobiliaria.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntidadeBase
    {
        protected readonly ImobiliariaDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ImobiliariaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(Guid id) =>
            await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IEnumerable<TEntity>> ListAllAsync() =>
            await _dbSet.ToListAsync();

        public async Task<IEnumerable<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task AddAsync(TEntity entity) =>
            await _dbSet.AddAsync(entity);

        public Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity); 
            return Task.CompletedTask;
        }
    }
}
