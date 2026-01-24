namespace API.Imobiliaria.Dominio.Enum
{
    public enum StatusImovel
    {
        Disponivel = 1,
        Reservado = 2,
        Vendido = 3,
        Alugado = 4
    }

    public enum Finalidade
    {
        Venda = 1,
        Aluguel = 2
    }

    public enum StatusProposta
    {
        Pendente = 1,
        Aceita = 2,
        Recusada = 3
    }
}
