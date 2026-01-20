using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Imobiliaria.Dominio.Entidades
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        // Admin, Corretor, Cliente
    }

}
