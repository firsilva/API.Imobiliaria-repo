using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

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

    //public class Repository <T> : IRepository<T> where T : EntidadeBase, new()
    //{
    //    protected readonly ImobiliariaDbContext Db;
    //    protected readonly DbSet<T> DbSet;
    //    protected Repository(MedicalHealthContext db)
    //    {
    //        Db = db;
    //        DbSet = db.Set<T>();
    //    }
    //    public async Task<T> ObterPorIdAsync(Guid id)
    //    {
    //        return await DbSet.FirstOrDefaultAsync(x => x.Id == id && x.Excluido == false);
    //    }

    //    public async Task<IEnumerable<T>> ObterPorListaIdAsync(List<Guid> id)
    //    {
    //        return await DbSet.Where(x => id.Contains(x.Id) && x.Excluido == false).ToListAsync();
    //    }

    //    public async Task<IEnumerable<T>> ObterTodosAsync()
    //    {
    //        return await DbSet.Where(x => x.Excluido == false).ToListAsync();
    //    }

    //    public async Task AdicionarAsync(T entidade)
    //    {
    //        DbSet.Add(entidade);
    //        await SalvarAsync();
    //    }

    //    public async Task AtualizarAsync(T entidade)
    //    {
    //        DbSet.Update(entidade);
    //        await SalvarAsync();
    //    }

    //    public async void Dispose()
    //    {
    //        Db?.Dispose();
    //    }

    //    public async Task RemoverAsync(T entidade)
    //    {
    //        DbSet.Update(entidade);
    //        await SalvarAsync();
    //    }

    //    public async Task<bool> SalvarAsync()
    //    {
    //        return await Db.CommitAsync();
    //    }
    //}
}
