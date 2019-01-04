using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbquartofoto
    {
        public int Idquartoimagem { get; set; }
        public int Idquarto { get; set; }
        public string Imagem { get; set; }
        public int Idusuarioatualizacao { get; set; }
        public DateTime Dataatualizacao { get; set; }
    }
}
