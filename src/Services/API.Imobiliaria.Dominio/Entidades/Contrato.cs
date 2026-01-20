using API.Imobiliaria.Dominio.Enum;

namespace API.Imobiliaria.Dominio.Entidades
{
    public class Contrato
    {
        public Guid Id { get; set; }

        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }

        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Guid CorretorId { get; set; }
        public Corretor Corretor { get; set; }

        public decimal ValorFinal { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public TipoContrato Tipo { get; set; } // Venda ou Aluguel
    }
}
