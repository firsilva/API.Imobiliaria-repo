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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(id);
            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.ListarClientesAsync();            
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto dto)
        {
            var resultDto = await _clienteService.AdicionarClienteAsync(dto);
            return Created(string.Empty, resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteDto dto)
        {
            await _clienteService.AtualizarClienteAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _clienteService.RemoverClienteAsync(id);
            return Ok();
        }
    }
}
