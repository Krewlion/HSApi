using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Bairros
    {
        public Bairros()
        {
            Logradouros = new HashSet<Logradouros>();
        }

        public int CdBairro { get; set; }
        public int CdCidade { get; set; }
        public string DsBairroNome { get; set; }

        public Cidades CdCidadeNavigation { get; set; }
        public ICollection<Logradouros> Logradouros { get; set; }
    }
}
