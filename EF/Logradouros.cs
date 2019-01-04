using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Logradouros
    {
        public int CdLogradouro { get; set; }
        public int CdBairro { get; set; }
        public int CdTipoLogradouros { get; set; }
        public string DsLogradouroNome { get; set; }
        public string NoLogradouroCep { get; set; }

        public Bairros CdBairroNavigation { get; set; }
    }
}
