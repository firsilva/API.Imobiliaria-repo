using API.Imobiliaria.Aplicacao.ClienteApplication;
using API.Imobiliaria.Aplicacao.ClienteApplication.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Imobiliaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
            => _clienteService = clienteService;

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(id);

            if (cliente == null) 
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var clientes = await _clienteService.ListarClientesAsync();            
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultDto = await _clienteService.AdicionarClienteAsync(dto);
            return CreatedAtAction(nameof(Create), new { Nome = resultDto.Nome }, resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clienteService.AtualizarClienteAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        {
            await _clienteService.RemoverClienteAsync(id);
            return NoContent();
        }
    }
}
