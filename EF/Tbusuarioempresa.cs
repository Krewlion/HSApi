using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbusuarioempresa
    {
        public long Idusuarioempresa { get; set; }
        public string Nomeusuario { get; set; }
        public int Idempresa { get; set; }
        public string Login { get; set; }
        public byte[] Senha { get; set; }
        public string Cpf { get; set; }
    }
}
