using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Cidades
    {
        public Cidades()
        {
            Bairros = new HashSet<Bairros>();
        }

        public int CdUf { get; set; }
        public int CdCidade { get; set; }
        public string DsCidadeNome { get; set; }

        public Uf CdUfNavigation { get; set; }
        public ICollection<Bairros> Bairros { get; set; }
    }
}
