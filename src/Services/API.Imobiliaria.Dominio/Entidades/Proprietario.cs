namespace API.Imobiliaria.Dominio.Entidades
{
    public class Proprietario : Pessoa
    {
        public Guid Id { get; set; }

        public Endereco Endereco { get; set; }
        public ICollection<Imovel> Imoveis { get; set; }
    }
}
