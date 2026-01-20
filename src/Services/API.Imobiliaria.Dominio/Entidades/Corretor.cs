namespace API.Imobiliaria.Dominio.Entidades
{
    public class Corretor
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string CRECI { get; set; }
        public string Email { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Contrato> Contratos { get; set; }
    }
}
