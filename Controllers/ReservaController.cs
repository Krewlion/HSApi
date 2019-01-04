using HSApi.EF;
using HSApi.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReservaController : Controller
    {

        public Reserva reservaNegocio = new Reserva();
        public TipoPagamento tipoPagamentoNegocio = new TipoPagamento();

        [HttpGet]
        public IActionResult PesquisarQuartosParaReservaPelaData(string datas, int cdcidade, int cdbairro, string hotel, string hospedes)
        {
            var retorno = reservaNegocio.PesquisarQuartosSemReserva(datas, cdcidade, cdbairro, hotel, hospedes);

            if (reservaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = reservaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpPost]
        public IActionResult IncluirReserva([FromBody] DTOs.Reserva reserva)
        {
            return Ok(reservaNegocio.IncluirReserva(reserva));
        }

        [HttpGet]
        public IActionResult ListarReservasAtivas()
        {
            return Ok(reservaNegocio.ListarReservasAtivas());
        }

        [HttpPost]
        public IActionResult CheckOut([FromBody] DTOs.Reserva reserva)
        {
            return Ok(reservaNegocio.CheckOut(reserva.idreserva));
        }

        [HttpGet]
        public IActionResult ListarTipoPagamentos()
        {
            return Ok(tipoPagamentoNegocio.ListarTiposDePagamento());
        }

        [HttpGet]
        public ActionResult BuscarReservaPeloID(int idreserva)
        {
            return Ok(reservaNegocio.BuscarReservaPeloID(idreserva));
        }

        [HttpGet]
        public ActionResult BuscarReservaComCheckoutPeloID(int idreserva)
        {
            return Ok(reservaNegocio.BuscarReservaComCheckoutPeloID(idreserva));
        }

        [HttpPost]
        public ActionResult AdicionarProdutosReservaCheckout([FromBody] DTOs.Reserva produtos)
        {
            var retorno = reservaNegocio.AdicionarProdutosReservaCheckout(produtos);

            if (reservaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = reservaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPost]
        public ActionResult RealizarPagamento([FromBody] DTOs.Pagamento pagamento)
        {
            var retorno = reservaNegocio.RealizarPagamento(pagamento);

            if (reservaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = reservaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }


        [HttpGet]
        public IActionResult ListarPagamentosPelaReserva(int idreserva)
        {
            var retorno = reservaNegocio.ListarPagamentosPeloIDreserva(idreserva);

            if (reservaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = reservaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpDelete]
        public IActionResult RemoverPagamento(int idreserva)
        {
            var retorno = reservaNegocio.RemoverPagamento(idreserva);

            if (reservaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = reservaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpGet]
        public IActionResult ListarProdutosPorReserva(int idreserva)
        {
            var retorno = reservaNegocio.ListarProdutosPorReserva(idreserva);

            if (reservaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = reservaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPost]
        public IActionResult FinalizarReserva([FromBody] DTOs.Reserva reserva)
        {
            var retorno = reservaNegocio.FinalizarReserva(reserva);

            if (reservaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = reservaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpPost]
        public IActionResult CancelarReserva([FromBody] DTOs.Reserva reserva)
        {
            var retorno = reservaNegocio.FinalizarReserva(reserva);

            if (reservaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = reservaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }

    }
}
