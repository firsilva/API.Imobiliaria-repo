using Microsoft.AspNetCore.Mvc;

namespace API.Imobiliaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelController : ControllerBase
    {
        [HttpPost("CriarImovel")]
        public async Task<IActionResult> NovoImovel()
        {
            return Created("", "Criado com sucesso!");
        }

        [HttpPost("BuscarImovel")]
        public async Task<IActionResult> BuscarImovel()
        {
            return Ok();
        }

        [HttpPut("AlterarImovel")]
        public async Task<IActionResult> AlterarImovel()
        {
            return Ok();
        }

        [HttpDelete("RemoverImovel")]
        public async Task<IActionResult> DeletarImovel()
        {
            return Ok();
        }
    }
}
