using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Repository
{
    public class Repository <T> : IRepository<T> where T : EntidadeBase, new()
    {
        protected readonly ImobiliariaContext Db;
        protected readonly DbSet<T> DbSet;
        protected Repository(MedicalHealthContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }
        public async Task<T> ObterPorIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id && x.Excluido == false);
        }

        public async Task<IEnumerable<T>> ObterPorListaIdAsync(List<Guid> id)
        {
            return await DbSet.Where(x => id.Contains(x.Id) && x.Excluido == false).ToListAsync();
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await DbSet.Where(x => x.Excluido == false).ToListAsync();
        }

        public async Task AdicionarAsync(T entidade)
        {
            DbSet.Add(entidade);
            await SalvarAsync();
        }

        public async Task AtualizarAsync(T entidade)
        {
            DbSet.Update(entidade);
            await SalvarAsync();
        }

        public async void Dispose()
        {
            Db?.Dispose();
        }

        public async Task RemoverAsync(T entidade)
        {
            DbSet.Update(entidade);
            await SalvarAsync();
        }

        public async Task<bool> SalvarAsync()
        {
            return await Db.CommitAsync();
        }
    }
}
