using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbusuariocartao
    {
        public int Idusuariocartao { get; set; }
        public int Idusuario { get; set; }
        public string Numerocartao { get; set; }
        public string Datavencimento { get; set; }
        public string Cvv { get; set; }
        public string Nomecartao { get; set; }

        public Tbusuario IdusuarioNavigation { get; set; }
    }
}
