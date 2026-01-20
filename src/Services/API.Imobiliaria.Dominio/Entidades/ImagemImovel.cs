namespace API.Imobiliaria.Dominio.Entidades
{
    public class ImagemImovel
    {
        public Guid Id { get; set; }

        public string Url { get; set; }
        public bool Principal { get; set; }

        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }
    }
}
