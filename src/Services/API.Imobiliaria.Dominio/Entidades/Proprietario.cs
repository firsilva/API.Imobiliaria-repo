namespace API.Imobiliaria.Dominio.Entidades
{
    public class Proprietario
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Documento { get; set; } // CPF/CNPJ
        public string Email { get; set; }
        public string Telefone { get; set; }

        public ICollection<Imovel> Imoveis { get; set; }
    }
}
