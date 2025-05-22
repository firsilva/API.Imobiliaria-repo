using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

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



        [HttpGet]
        public async Task<IActionResult> BuscarImoveis(
            [FromQuery] string tipoImovel,  // Pode ser "Casa", "Apartamento", "Galpão", etc.
            [FromQuery] string bairro,
            [FromQuery] string cidade,
            [FromQuery] string estado,
            [FromQuery] decimal? precoMin,
            [FromQuery] decimal? precoMax,
            [FromQuery] int? quartosMin,
            [FromQuery] int? banheirosMin,
            [FromQuery] int? vagasMin,
            [FromQuery] decimal? areaMin,
            [FromQuery] string status,
            [FromQuery] string ordenarPor = "preco_desc"
        )
        {
            IQueryable<Imovel> query = _context.Imoveis.AsQueryable();

            // Filtros comuns a todos os tipos de imóvel
            if (!string.IsNullOrEmpty(bairro))
                query = query.Where(i => i.Bairro.Contains(bairro));

            if (!string.IsNullOrEmpty(cidade))
                query = query.Where(i => i.Cidade.Contains(cidade));

            if (!string.IsNullOrEmpty(estado))
                query = query.Where(i => i.Estado.Contains(estado));

            if (precoMin.HasValue)
                query = query.Where(i => i.Preco >= precoMin.Value);

            if (precoMax.HasValue)
                query = query.Where(i => i.Preco <= precoMax.Value);

            if (quartosMin.HasValue)
                query = query.Where(i => i.Quartos >= quartosMin.Value);

            if (banheirosMin.HasValue)
                query = query.Where(i => i.Banheiros >= banheirosMin.Value);

            if (vagasMin.HasValue)
                query = query.Where(i => i.VagasGaragem >= vagasMin.Value);

            if (areaMin.HasValue)
                query = query.Where(i => i.AreaTotal >= areaMin.Value);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(i => i.Status == status);

            // Filtrando por tipo de imóvel (opcional)
            if (!string.IsNullOrEmpty(tipoImovel))
            {
                switch (tipoImovel.ToLower())
                {
                    case "casa":
                        query = query.OfType<Casa>();
                        break;
                    case "apartamento":
                        query = query.OfType<Apartamento>();
                        break;
                    case "galpao":
                        query = query.OfType<Galpao>();
                        break;
                    case "salacomercial":
                        query = query.OfType<SalaComercial>();
                        break;
                    default:
                        break;  // Retorna todos os tipos de imóveis
                }
            }

            // Ordenação
            switch (ordenarPor.ToLower())
            {
                case "preco_asc":
                    query = query.OrderBy(i => i.Preco);
                    break;
                case "preco_desc":
                    query = query.OrderByDescending(i => i.Preco);
                    break;
                case "area_asc":
                    query = query.OrderBy(i => i.AreaTotal);
                    break;
                case "area_desc":
                    query = query.OrderByDescending(i => i.AreaTotal);
                    break;
                default:
                    query = query.OrderByDescending(i => i.Preco);
                    break;
            }

            // Executando a consulta
            var imoveis = await query.ToListAsync();

            return Ok(imoveis);
        }


        [HttpPost("{imovelId}/upload-imagem-base64")]
        public async Task<IActionResult> UploadImagemBase64(Guid imovelId, [FromBody] ImagemBase64Dto imagemBase64Dto)
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
                IsCapa = imagemBase64Dto.IsCapa
            };

            _context.Imagens.Add(novaImagem);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Imagem salva com sucesso!" });
        }
    }
}
