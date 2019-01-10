using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbusuario
    {
        public Tbusuario()
        {
            Tbreserva = new HashSet<Tbreserva>();
            Tbusuariocartao = new HashSet<Tbusuariocartao>();
        }

        public int Idusuario { get; set; }
        public string Nomeusuario { get; set; }
        public string Loginusuario { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime Datanascimento { get; set; }
        public byte[] Senha { get; set; }

        public ICollection<Tbreserva> Tbreserva { get; set; }
        public ICollection<Tbusuariocartao> Tbusuariocartao { get; set; }
    }
}
