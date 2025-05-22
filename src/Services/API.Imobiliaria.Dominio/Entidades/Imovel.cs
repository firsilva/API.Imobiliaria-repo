using API.Imobiliaria.Dominio.Enum;

namespace API.Imobiliaria.Dominio.Entidades
{
    public class Imovel : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal AreaConstruida { get; set; }
        public TipoImovelEnum TipoImovel { get; set; }  // Tipo de imóvel (Casa, Apartamento, etc.)
        public StatusImovelEnum Status { get; set; }

        // Relacionamento com imagens
        public List<Imagem> Imagem { get; set; }
    }
}
