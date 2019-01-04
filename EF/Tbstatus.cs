using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbstatus
    {
        public Tbstatus()
        {
            Tbquarto = new HashSet<Tbquarto>();
        }

        public int Idstatus { get; set; }
        public string Status { get; set; }

        public ICollection<Tbquarto> Tbquarto { get; set; }
    }
}
