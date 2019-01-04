using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class Quarto
    {
        public int idquarto { get; set; }
        public string quarto { get; set; }
        public string nomeempresa { get; set; }
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
    }
}
