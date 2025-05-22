namespace API.Imobiliaria.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ObterPorListaIdAsync(List<Guid> id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
    }
}
