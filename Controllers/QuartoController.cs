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
    public class QuartoController : Controller
    {

        Quarto quartoNegocio = new Quarto();

        [HttpPost]
        public IActionResult IncluirQuarto([FromBody]DTOs.Quarto quarto)
        {
            return Ok(quartoNegocio.IncluirQuarto(quarto));
        }

        [HttpGet]
        public IActionResult AutoComplete(string nome)
        {
            var retorno = quartoNegocio.AutoComplete(nome);
            return Ok(retorno.Select(x => new { Quarto = x.Quarto, idQuarto = x.Idquarto, exibir = "ID: " + x.Idquarto + " - NOME: " + x.Quarto }).ToList());
        }

        [HttpPost]
        public IActionResult BuscarQuarto([FromBody] DTOs.Quarto quarto)
        {
            var retorno = quartoNegocio.Buscar(quarto.idquarto);
            return Ok(
                new
                {
                    Quarto = retorno.quarto,
                    idQuarto = retorno.idquarto,
                    Varanda = retorno.varanda,
                    Arcondicionado = retorno.arcondicionado,
                    Camacasal = retorno.camacasal,
                    Camasolteiro = retorno.camasolteiro,
                    Status = retorno.status,
                    Valor = retorno.valor,
                }
                );
        }
        [HttpPost]
        public IActionResult AlterarQuarto([FromBody] DTOs.Quarto quarto)
        {
            var retorno = quartoNegocio.AlterarQuarto(quarto);
            return Ok(retorno);
        }

        [HttpGet]
        public IActionResult ListarTodosQuartosParaAlugar()
        {
            return Ok(quartoNegocio.ListarTodosQuartosParaAlugar());
        }
    }
}
