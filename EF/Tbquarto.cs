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
        public int Idtipoquarto { get; set; }
        public string Quarto { get; set; }
        public int? Status { get; set; }
        public string Andar { get; set; }

        public Tbtipoquarto IdtipoquartoNavigation { get; set; }
        public ICollection<Tbreserva> Tbreserva { get; set; }
    }
}
