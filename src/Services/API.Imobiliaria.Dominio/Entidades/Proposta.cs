using API.Imobiliaria.Dominio.Enum;

namespace API.Imobiliaria.Dominio.Entidades
{
    public class Proposta : EntidadeBase
    {
        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }

        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public decimal Valor { get; set; }
        public StatusProposta Status { get; set; }

        public DateTime DataProposta { get; set; }
    }
}
