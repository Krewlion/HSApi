using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSApi.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EnderecoController : Controller
    {
        public Endereco endereco = new Endereco();
        public IActionResult ListarCidades(string cidade)
        {
            var retorno = endereco.ListarCidades(cidade);

            if (endereco.erros.Count > 0)
            {
                return Ok(new { erros = endereco.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }

        public IActionResult ListarMunicipios(string bairro)
        {
            var retorno = endereco.ListarBairros(bairro);

            if (endereco.erros.Count > 0)
            {
                return Ok(new { erros = endereco.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }
    }
}