using API.Imobiliaria.Dominio.Enum;

namespace API.Imobiliaria.Dominio.Entidades
{
    public class Imovel : EntidadeBase
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public decimal Preco { get; set; }
        public decimal? ValorCondominio { get; set; }
        public decimal? ValorIPTU { get; set; }

        public double AreaTotal { get; set; }
        public double AreaConstruida { get; set; }
        public int? QtdQuartos { get; set; }
        public int? QtdBanheiros { get; set; }
        public int? VagasGaragem { get; set; }

        public StatusImovel Status { get; set; }
        public Finalidade Finalidade { get; set; }

        public Guid TipoImovelId { get; set; }
        public TipoImovel TipoImovel { get; set; }

        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public Guid ProprietarioId { get; set; }
        public Proprietario Proprietario { get; set; }

        public ICollection<Imagem> Imagem { get; set; }
        public ICollection<ImovelCaracteristica> Caracteristicas { get; set; }
    }

}
