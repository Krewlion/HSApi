using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbcartaocliente
    {
        public long Idcartao { get; set; }
        public int Idcliente { get; set; }
        public string Numerocartao { get; set; }
        public string Cvv { get; set; }
        public string Datavencimento { get; set; }
        public int Idusuarioatualizacao { get; set; }
        public DateTime Dataatualizacao { get; set; }
    }
}
