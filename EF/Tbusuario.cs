using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbusuario
    {
        public int Idusuario { get; set; }
        public int? Idempresa { get; set; }
        public string Nomeusuario { get; set; }
        public string Loginusuario { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime? Datanascimento { get; set; }
        public byte[] Senha { get; set; }
    }
}
