using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class CartaoUsuario
    {
        public int idusuariocartao { get; set; }
        public int idusuario { get; set; }
        public string numerocartao { get; set; }
        public string datavencimento { get; set; }
        public string cvv { get; set; }
        public string nomecartao { get; set; }
        public string idusuariocripto { get; set; }
    }
}
