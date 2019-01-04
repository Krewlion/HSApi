using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbreserva
    {
        public Tbreserva()
        {
            Tbpagamento = new HashSet<Tbpagamento>();
            Tbprodutoreserva = new HashSet<Tbprodutoreserva>();
        }

        public int Idreserva { get; set; }
        public DateTime? Dataentrada { get; set; }
        public DateTime? Datasaida { get; set; }
        public DateTime Datacadastro { get; set; }
        public int Idcliente { get; set; }
        public int Idquarto { get; set; }
        public bool? Checkout { get; set; }
        public DateTime? Datafinalizacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Datacancelamento { get; set; }
        public string Motivocancelamento { get; set; }

        public Tbcliente IdclienteNavigation { get; set; }
        public Tbquarto IdquartoNavigation { get; set; }
        public ICollection<Tbpagamento> Tbpagamento { get; set; }
        public ICollection<Tbprodutoreserva> Tbprodutoreserva { get; set; }
    }
}
