using HSApi.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsuarioController:Controller
    {
        public Usuario UsuarioNegocio = new Usuario();
        [HttpPost]
        public IActionResult Entrar()
        {
            return null;
        }

        [HttpPost]
        public IActionResult IncluirUsuario([FromBody] DTOs.Usuario usuario)
        {
            var retorno = UsuarioNegocio.IncluirUsuario(usuario);

            if (UsuarioNegocio.erros.Count > 0)
            {
                return Ok(new { erros = UsuarioNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }
    }
}
