namespace API.Imobiliaria.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }

        public string SenhaHash { get; set; }
        public string SenhaSalt { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
