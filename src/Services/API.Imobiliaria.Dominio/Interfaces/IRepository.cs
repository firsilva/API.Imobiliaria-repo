namespace API.Imobiliaria.Dominio.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ObterPorListaIdAsync(List<Guid> id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
    }
}
