using HSApi.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TipoQuartoController : Controller
    {
        public TipoQuarto tipoQuartoNegocio = new TipoQuarto();
        public IActionResult ListarTipoQuartosPelaEmpresa(int idempresa)
        {

            var retorno = tipoQuartoNegocio.Listar(idempresa);

            if (tipoQuartoNegocio.erros.Count > 0)
            {
                return Ok(new { erros = tipoQuartoNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }
    }
}
