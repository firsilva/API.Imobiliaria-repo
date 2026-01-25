using API.Imobiliaria.Aplicacao.ClienteApplication;
using API.Imobiliaria.Aplicacao.ClienteApplication.Dto;
using API.Imobiliaria.Dominio.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Imobiliaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(id);
            if (cliente == null) return NotFound();

            var dto = _mapper.Map<ClienteReadDto>(cliente);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.ListarClientesAsync();
            var dtoList = _mapper.Map<IEnumerable<ClienteReadDto>>(clientes);
            return Ok(dtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteCreateDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            await _clienteService.AdicionarClienteAsync(cliente);

            var resultDto = _mapper.Map<ClienteReadDto>(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, resultDto);
        }
    }
}
