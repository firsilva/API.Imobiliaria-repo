namespace API.Imobiliaria.Aplicacao.ClienteApplication
{
    public interface IClienteService
    {
        Task<Dominio.Entidades.Cliente> ObterClientePorIdAsync(Guid id);
        Task<IEnumerable<Dominio.Entidades.Cliente>> ListarClientesAsync();
        Task AdicionarClienteAsync(Dominio.Entidades.Cliente cliente);
        Task AtualizarClienteAsync(Dominio.Entidades.Cliente cliente);
        Task RemoverClienteAsync(Dominio.Entidades.Cliente cliente);
    }
}
