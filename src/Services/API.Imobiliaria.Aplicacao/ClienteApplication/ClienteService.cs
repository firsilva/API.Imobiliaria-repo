using API.Imobiliaria.Aplicacao.ClienteApplication.Dto;
using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Data.Repository;
using AutoMapper;

namespace API.Imobiliaria.Aplicacao.ClienteApplication
{
    public class ClienteService : IClienteService
    {
        private readonly Repository<Dominio.Entidades.Cliente> _clienteRepository;
        private readonly ImobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(Repository<Dominio.Entidades.Cliente> clienteRepository, ImobiliariaDbContext context, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClienteDto> ObterClientePorIdAsync(Guid clienteId)
        {
            var cliente = await _clienteRepository.GetByIdAsync(clienteId);
            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<ClienteDto> AdicionarClienteAsync(ClienteDto dto)
        {
            var cliente = _mapper.Map<Dominio.Entidades.Cliente>(dto);

            await _clienteRepository.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task AtualizarClienteAsync(ClienteDto cliente)
        {
            //var cliente = await _clienteRepository.GetByIdAsync(cliente.Email);

            //await _clienteRepository.UpdateAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClienteDto>> ListarClientesAsync()
        {
            //var clientes = await _clienteRepository.ListAllAsync();
            var clientes = await _clienteRepository.ListAsync(x => x.Endereco);
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        public async Task RemoverClienteAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            await _clienteRepository.DeleteAsync(cliente);
            await _context.SaveChangesAsync(); // Soft Delete
        }
    }
}
