namespace API.Imobiliaria.Dominio.Entidades
{
    public class Role : EntidadeBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        // Admin, Corretor, Cliente
    }

}
