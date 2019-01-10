using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbempresa
    {
        public Tbempresa()
        {
            Tbtipoquarto = new HashSet<Tbtipoquarto>();
        }

        public int Idempresa { get; set; }
        public string Cnpj { get; set; }
        public string Nomeempresa { get; set; }
        public string Razaosocial { get; set; }
        public string Cep { get; set; }
        public string Complemente { get; set; }
        public string Numero { get; set; }
        public DateTime Datacadastro { get; set; }
        public string Horachekin { get; set; }
        public string Horacheckout { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public Logradouros CepNavigation { get; set; }
        public ICollection<Tbtipoquarto> Tbtipoquarto { get; set; }
    }
}
