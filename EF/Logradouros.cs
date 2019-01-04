using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Logradouros
    {
        public Logradouros()
        {
            Tbempresa = new HashSet<Tbempresa>();
        }

        public int CdLogradouro { get; set; }
        public int CdBairro { get; set; }
        public int CdTipoLogradouros { get; set; }
        public string DsLogradouroNome { get; set; }
        public string NoLogradouroCep { get; set; }

        public Bairros CdBairroNavigation { get; set; }
        public ICollection<Tbempresa> Tbempresa { get; set; }
    }
}
