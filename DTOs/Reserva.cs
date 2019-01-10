using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.DTOs
{
    public class Reserva
    {
        public int idreserva { get; set; }
        public int idquarto { get; set; }
        public int idcliente { get; set; }
        public string valor { get; set; }
        public string dataentrada { get; set; }
        public string datasaida { get; set; }
        public string datacadastro { get; set; }
        public bool checkout { get; set; }
        public string datafinalizacao { get; set; }
        public string valorpagamento { get; set; }
        public string datapagamento { get; set; }
        public string nomecliente { get; set; }
        public string quarto { get; set; }
        public string cpf { get; set; }
        public string tipopagamento { get; set; }
        public int idtipopagamento { get; set; }
        public string chavepagamento { get; set; }
        public string valorcheckout { get; set; }
        public string idusuariocripto { get; set; }
        public string motivocancelamento { get; set; }
        public List<DTOs.produtosReserva> produtos { get; set; }
    }

}
