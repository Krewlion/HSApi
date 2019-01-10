using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbcliente
    {
        public int Idcliente { get; set; }
        public string Nomecliente { get; set; }
        public string Cpf { get; set; }
        public string Rgcliente { get; set; }
        public DateTime? Datanascimento { get; set; }
        public string Telefonefixo { get; set; }
        public string Telefonecelular { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public byte[] Senha { get; set; }
    }
}
