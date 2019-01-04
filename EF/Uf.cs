using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Uf
    {
        public Uf()
        {
            Cidades = new HashSet<Cidades>();
        }

        public int CdUf { get; set; }
        public string DsUfSigla { get; set; }
        public string DsUfNome { get; set; }

        public ICollection<Cidades> Cidades { get; set; }
    }
}
