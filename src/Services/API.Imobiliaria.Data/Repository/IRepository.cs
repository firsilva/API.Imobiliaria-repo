using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ListAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
