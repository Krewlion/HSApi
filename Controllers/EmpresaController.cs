using HSApi.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmpresaController : Controller
    {
        public Empresa empresaNegocio = new Empresa();

        public IActionResult BuscarEmpresa(int idempresa)
        {

            var retorno = empresaNegocio.BuscarEmpresa(idempresa);

            if (empresaNegocio.erros.Count > 0)
            {
                return Ok(new { erros = empresaNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }


    }
}
