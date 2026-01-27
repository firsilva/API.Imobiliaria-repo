namespace API.Imobiliaria.Dominio.Entidades
{
    public class Imagem : EntidadeBase
    {
        public string Url { get; set; }
        public bool Capa { get; set; }
        public string ImagemBase64 { get; set; }

        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }
    }
}
