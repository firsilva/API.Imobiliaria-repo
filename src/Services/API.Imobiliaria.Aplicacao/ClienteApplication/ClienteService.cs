using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Data.Repository;

namespace API.Imobiliaria.Aplicacao.ClienteApplication
{
    public class ClienteService : IClienteService
    {
        private readonly Repository<Dominio.Entidades.Cliente> _clienteRepository;
        private readonly ImobiliariaDbContext _context;

        public ClienteService(Repository<Dominio.Entidades.Cliente> clienteRepository, ImobiliariaDbContext context)
        {
            _clienteRepository = clienteRepository;
            _context = context;
        }

        public async Task<Dominio.Entidades.Cliente> ObterClientePorIdAsync(Guid clienteId)
        {
            return await _clienteRepository.GetByIdAsync(clienteId);
        }

        public async Task AdicionarClienteAsync(Dominio.Entidades.Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarClienteAsync(Dominio.Entidades.Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dominio.Entidades.Cliente>> ListarClientesAsync()
        {
            return await _clienteRepository.ListAllAsync();
        }

        public async Task RemoverClienteAsync(Dominio.Entidades.Cliente cliente)
        {
            await _clienteRepository.DeleteAsync(cliente);
            await _context.SaveChangesAsync(); // Soft Delete
        }
    }
}
