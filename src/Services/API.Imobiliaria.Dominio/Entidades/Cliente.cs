namespace API.Imobiliaria.Dominio.Entidades
{
    public class Cliente : Pessoa
    {
        protected Cliente() { } // EF

        public Cliente(string nome, string email, string telefone, string documento, Guid? usuarioId) : base(nome, email, telefone, documento)
        {
            UsuarioId = usuarioId;
            Propostas = new List<Proposta>();
        }

        public void DefinirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public Guid? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Guid? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public ICollection<Proposta> Propostas { get; set; }
    }
}
