using HSApi.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        Login negocio = new Login();
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration iconfiguration)
        {
            _configuration = iconfiguration;
        }

        [HttpPost]
        public IActionResult Logar([FromBody] DTOs.Usuario usuario)
        {
            var usu = negocio.logar(usuario);

            if (negocio.erros.Count > 0)
            {
                return Ok(new { erros = negocio.erros });
            }
            else
            {
                return Ok(usu);
            }

        }
    }
}
