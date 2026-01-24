using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Imobiliaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelController : ControllerBase
    {
        private readonly ImobiliariaDbContext _context;

        public ImovelController(ImobiliariaDbContext context)
        {
            _context = context;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> NovoImovel()
        {
            return Created("", "Criado com sucesso!");
        }

        [HttpPost("Buscar")]
        public async Task<IActionResult> BuscarImovel()
        {
            return Ok();
        }

        [HttpPut("Alterar")]
        public async Task<IActionResult> AlterarImovel()
        {
            return Ok();
        }

        [HttpDelete("Remover")]
        public async Task<IActionResult> DeletarImovel()
        {
            return Ok();
        }

        [HttpPost("{imovelId}/upload-imagem-base64")]
        public async Task<IActionResult> UploadImagemBase64(Guid imovelId, [FromBody] Imagem imagemBase64Dto)
        {
            // Verifica se o imóvel existe
            var imovel = await _context.Imoveis.FindAsync(imovelId);
            if (imovel == null)
            {
                return NotFound("Imóvel não encontrado.");
            }

            // Valida a string Base64
            if (string.IsNullOrEmpty(imagemBase64Dto.ImagemBase64))
            {
                return BadRequest("Imagem Base64 não fornecida.");
            }

            // Aqui você pode validar se a string Base64 realmente representa uma imagem válida, mas por agora, vamos apenas salvar.

            // Salva a imagem Base64 no banco de dados
            var novaImagem = new Imagem
            {
                ImovelId = imovelId,
                ImagemBase64 = imagemBase64Dto.ImagemBase64,
                Capa = imagemBase64Dto.Capa
            };

            _context.Imagens.Add(novaImagem);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Imagem salva com sucesso!" });
        }
    }
}
