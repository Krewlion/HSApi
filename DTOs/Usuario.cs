using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class Usuario
    {
        public string idusuariocripto { get; set; }
        public int idusuario { get; set; }
        public string nomeusuario { get; set; }
        public string loginusuario { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string datanascimento { get; set; }
        public string senha { get; set; }
        public bool manter { get; set; }
        public string grupo { get; set; }
        public int idusuarioatualizacao { get; set; }
        public int idgrupo { get; set; }

    }
}
