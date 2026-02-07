using API.Imobiliaria.Aplicacao.ClienteApplication.Dto;

namespace API.Imobiliaria.Aplicacao.ClienteApplication
{
    public interface IClienteService
    {
        Task<ClienteDto> ObterClientePorIdAsync(Guid id);
        Task<IEnumerable<ClienteDto>> ListarClientesAsync();
        Task<ClienteDto> AdicionarClienteAsync(ClienteDto cliente);
        Task AtualizarClienteAsync(ClienteDto cliente);
        Task RemoverClienteAsync(Guid id);
    }
}
