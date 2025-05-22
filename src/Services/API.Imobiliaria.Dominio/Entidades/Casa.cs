namespace API.Imobiliaria.Dominio.Entidades
{
    public class Casa : Imovel
    {
        public bool TemJardim { get; set; }
        public bool TemPiscina { get; set; }
        public int Andares { get; set; }
        public int Quartos { get; set; }
    }
}
