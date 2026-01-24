namespace API.Imobiliaria.Dominio.Entidades
{
    public class ImovelCaracteristica : EntidadeBase
    {
        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }

        public Guid CaracteristicaId { get; set; }
        public Caracteristica Caracteristica { get; set; }
    }
}
