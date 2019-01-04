using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbproduto
    {
        public Tbproduto()
        {
            Tbprodutoreserva = new HashSet<Tbprodutoreserva>();
        }

        public int Idproduto { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }

        public ICollection<Tbprodutoreserva> Tbprodutoreserva { get; set; }
    }
}
