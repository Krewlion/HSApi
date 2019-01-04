using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class Pagamento
    {
        public int idpagamento { get; set; }
        public int idtipopagamento { get; set; }
        public string tipopagamento { get; set; }
        public int idreserva { get; set; }
        public string chavepagamento { get; set; }
        public string valor { get; set; }
        public string datapagamento { get; set; }

    }
}
