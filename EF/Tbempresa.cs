using System;
using System.Collections.Generic;

namespace HSApi.EF
{
    public partial class Tbempresa
    {
        public Tbempresa()
        {
            Tbquarto = new HashSet<Tbquarto>();
        }

        public int Idempresa { get; set; }
        public string Cnpj { get; set; }
        public string Nomeempresa { get; set; }
        public string Razaosocial { get; set; }
        public string Cep { get; set; }
        public string Complemente { get; set; }
        public string Numero { get; set; }
        public DateTime? Datacadastro { get; set; }

        public ICollection<Tbquarto> Tbquarto { get; set; }
    }
}
