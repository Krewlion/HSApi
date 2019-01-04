using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class AbstractNegocio
    {
        public List<string> erros { get; set; }
        public List<string> inner { get; set; }

        public AbstractNegocio()
        {
            erros = new List<string>();
            inner = new List<string>();
        }

    }
}
