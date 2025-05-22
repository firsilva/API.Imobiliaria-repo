namespace API.Imobiliaria.Dominio.Entidades
{
    public class Apartamento : Imovel
    {
        public bool TemPiscina { get; set; }
        public int Andares { get; set; }
        public int Quartos { get; set; }
        public string Andar { get; set; }
    }
}
