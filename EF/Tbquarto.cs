using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbquarto
    {
        public Tbquarto()
        {
            Tbreserva = new HashSet<Tbreserva>();
        }

        public int Idquarto { get; set; }
        public int Idempresa { get; set; }
        public string Quarto { get; set; }
        public int? Camacasal { get; set; }
        public int? Camasolteiro { get; set; }
        public bool? Arcondicionado { get; set; }
        public decimal? Valor { get; set; }
        public bool? Varanda { get; set; }
        public int? Status { get; set; }
        public string Andar { get; set; }
        public int Totalpessoas { get; set; }
        public bool Banheiroprivativo { get; set; }
        public bool Ventilador { get; set; }

        public Tbempresa IdempresaNavigation { get; set; }
        public Tbstatus StatusNavigation { get; set; }
        public ICollection<Tbreserva> Tbreserva { get; set; }
    }
}
