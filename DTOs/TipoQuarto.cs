using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class TipoQuarto
    {
        public int idtipoquarto { get; set; }
        public string tipoquarto { get; set; }
        public List<Quarto> quartos { get; set; }
        public int camacasal { get; set; }
        public int camasolteiro { get; set; }
        public bool arcondicionado { get; set; }
        public bool varanda { get; set; }
        public string valor { get; set; }
        public int status { get; set; }
        public List<string> imagens { get; set; }
        public string foto { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string hotel { get; set; }
        public string checkin { get; set; }
        public string checkout { get; set; }
        public int qtdhospedes { get; set; }
        public bool banheiroprivativo { get; set; }
        public bool ventilador { get; set; }
        public int idempresa { get; set; }
        public bool vistamar { get; set; }
        public bool vistapordosol { get; set; }
        public bool banheira { get; set; }
    }
}
