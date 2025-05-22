namespace API.Imobiliaria.Dominio.Entidades
{
    public class Imagem : EntidadeBase
    {
        // Relacionamento com o imóvel
        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }

        // Imagem em Base64
        public string ImagemBase64 { get; set; }

        // Informações adicionais (opcional)
        public bool IsCapa { get; set; }  // Se essa imagem é a capa principal do imóvel
    }
}
