using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class Empresa
    {
        public int idempresa { get; set; }
        public string cnpj { get; set; }
        public string nomeempresa { get; set; }
        public string razaosocial { get; set; }
        public string cep { get; set; }
        public string complemente { get; set; }
        public string numero { get; set; }
        public DateTime datacadastro { get; set; }
        public string horachekin { get; set; }
        public string horacheckout { get; set; }
        public string logradouro { get; set; }
    }
}
