using API.Imobiliaria.Dominio.Entidades;
using System.Linq.Expressions;

namespace API.Imobiliaria.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ListAllAsync();
        Task<IEnumerable<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] includes);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
