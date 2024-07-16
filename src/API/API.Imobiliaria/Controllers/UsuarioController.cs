using Microsoft.AspNetCore.Mvc;


namespace API.Imobiliaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("CriarUsuario")]
        public async Task<IActionResult> NovoUsuario()
        {
            return Created("", "Criado com sucesso!");
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> Autenticar()
        {
            return Ok("Logado");
        }

        [HttpPost("BuscarUsuario")]
        public async Task<IActionResult> BuscarUsuario()
        {
            return Ok();
        }

        [HttpPut("AlterarUsuario")]
        public async Task<IActionResult> AlterarUsuario()
        {
            return Ok();
        }

        [HttpDelete("RemoverUsuario")]
        public async Task<IActionResult> DeletarUsuario()
        {
            return Ok();
        }
    }
}
