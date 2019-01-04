using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class Cliente
    {
        public int idcliente { get; set; }
        public string nomeCliente { get; set; }
        public string cpf { get; set; }
        public string rgcliente { get; set; }
        public string datanascimento { get; set; }
        public string telefonefixo { get; set; }
        public string telefonecelular { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string senha { get; set; }
    }
}
