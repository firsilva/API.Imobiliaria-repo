namespace API.Imobiliaria.Dominio.Entidades
{
    public class Pessoa : EntidadeBase
    {
        protected Pessoa() { } // EF

        protected Pessoa(string nome, string email, string telefone, string documento)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Documento = documento;
        }

        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Telefone { get; protected set; }
        public string Documento { get; protected set; } // CPF/CNPJ
    }
}
