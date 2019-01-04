using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class Endereco
    {
        public int cdcidade { get; set; }
        public int cdbairro { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
    }
}
