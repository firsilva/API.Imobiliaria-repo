using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Imobiliaria.Dominio.Enum
{
    public enum StatusImovel
    {
        Disponivel = 1,
        Reservado = 2,
        Vendido = 3,
        Alugado = 4
    }

    public enum FinalidadeImovel
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

    public enum TipoContrato
    {
        Venda = 1,
        Aluguel = 2
    }

}
