using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbprodutoreserva
    {
        public int Idprodutocheckout { get; set; }
        public int? Idproduto { get; set; }
        public int? Idreserva { get; set; }
        public decimal? Valor { get; set; }
        public int? Quantidade { get; set; }

        public Tbproduto IdprodutoNavigation { get; set; }
        public Tbreserva IdreservaNavigation { get; set; }
    }
}
