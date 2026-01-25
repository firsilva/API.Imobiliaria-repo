namespace API.Imobiliaria.Dominio.Entidades
{
    public class Corretor : Pessoa
    {
        public string Creci { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
    }
}
