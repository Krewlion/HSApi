using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class Empresa_Quartos
    {
        public int idempresa { get; set; }
        public List<TipoQuarto> tipoquartos { get; set; }
        public string nomeempresa { get; set; }
        public decimal maisbarato { get; set; }
        public string checkin { get; set; }
        public string checkout { get; set; }
    }
}
