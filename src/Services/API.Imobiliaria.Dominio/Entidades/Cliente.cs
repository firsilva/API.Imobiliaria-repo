namespace API.Imobiliaria.Dominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Guid? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Proposta> Propostas { get; set; }
    }
}
