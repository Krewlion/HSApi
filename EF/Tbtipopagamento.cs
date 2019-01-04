using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbtipopagamento
    {
        public Tbtipopagamento()
        {
            Tbpagamento = new HashSet<Tbpagamento>();
        }

        public int Idtipopagamento { get; set; }
        public string Tipopagamento { get; set; }

        public ICollection<Tbpagamento> Tbpagamento { get; set; }
    }
}
