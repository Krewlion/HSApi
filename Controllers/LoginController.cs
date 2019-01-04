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

                //var claims = new[]
                //{
                //    new Claim(ClaimTypes.Name, usuario.loginusuario)
                //};

                //var key = new SymmetricSecurityKey(
                //    Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                //var creds = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);

                //var token = new JwtSecurityToken(
                // issuer: "Metanoia",
                // audience: "Metanoia",
                // claims: claims,
                // expires: DateTime.Now.AddMinutes(30),
                // signingCredentials: creds
                //);

                //var tokenRetorno = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { cpf = usu.Cpf, email = usu.Email, idusuario = usu.Idusuario, nome = usu.Nomeusuario, loginusuario = usu.Loginusuario });
            }

        }
    }
}
