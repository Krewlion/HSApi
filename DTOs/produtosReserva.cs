using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class produtosReserva
    {
        public int idproduto { get; set; }
        public string descricao { get; set; }
        public string valor { get; set; }
        public int quantidade { get; set; }
        public int idreserva { get; set; }
        public int idprodutocheckout { get;set;}
    }
}
