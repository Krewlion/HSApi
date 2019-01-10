using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbtipoquarto
    {
        public Tbtipoquarto()
        {
            Tbquarto = new HashSet<Tbquarto>();
        }

        public int Idtipoquarto { get; set; }
        public int Idempresa { get; set; }
        public string Tipoquarto { get; set; }
        public short Camacasal { get; set; }
        public short Camasolteiro { get; set; }
        public bool Arcondicionado { get; set; }
        public decimal Valor { get; set; }
        public bool Varanda { get; set; }
        public bool Vistamar { get; set; }
        public short Totalpessoas { get; set; }
        public bool Banheiroprivativo { get; set; }
        public bool Ventilador { get; set; }
        public bool Vistapordosol { get; set; }
        public bool Banheira { get; set; }

        public Tbempresa IdempresaNavigation { get; set; }
        public ICollection<Tbquarto> Tbquarto { get; set; }
    }
}
