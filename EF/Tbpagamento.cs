using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbpagamento
    {
        public int Idpagamento { get; set; }
        public DateTime? Datapagamento { get; set; }
        public int Idtipopagamento { get; set; }
        public int Idreserva { get; set; }
        public string Chavepagamento { get; set; }
        public decimal Valor { get; set; }

        public Tbreserva IdreservaNavigation { get; set; }
        public Tbtipopagamento IdtipopagamentoNavigation { get; set; }
    }
}
