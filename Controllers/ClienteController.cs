using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSApi.EF;
using HSApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ClienteController : Controller
    {
        public Cliente clienteNegocio = new Cliente();
        // GET: Cliente
        [HttpPost]
        public IActionResult IncluirCliente([FromBody] DTOs.Cliente cliente)
        {
            var retorno = clienteNegocio.IncluirCliente(cliente);

            if (clienteNegocio.erros.Count > 0)
            {
                return Ok(new { erros = clienteNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpGet]
        public IActionResult AutoComplete(string nome)
        {
            var retorno = clienteNegocio.AutoComplete(nome);
            if (clienteNegocio.erros.Count > 0)
            {
                return Ok(new { erros = clienteNegocio.erros });
            }
            else
            {
                return Ok(retorno.Select(x => new { cpf = x.Cpf, Nomecliente = x.Nomecliente, Idcliente = x.Idcliente, exibir = "ID: " + x.Idcliente + " - NOME: " + x.Nomecliente + " - CPF: " + x.Cpf }).ToList());
            }
        }

        [HttpPost]
        public IActionResult BuscarCliente([FromBody] DTOs.Cliente cliente)
        {
            var retorno = clienteNegocio.Buscar(cliente.idcliente);
            if (clienteNegocio.erros.Count > 0)
            {
                return Ok(new { erros = clienteNegocio.erros });
            }
            else
            {
                return Ok(
                new
                {
                    Nomecliente = retorno.Nomecliente,
                    Cep = retorno.Cep,
                    Complemento = retorno.Complemento,
                    Cpf = retorno.Cpf,
                    Datanascimento = retorno.Datanascimento.Value.Day.ToString("00") + "/" + retorno.Datanascimento.Value.Month.ToString("00") + "/" + retorno.Datanascimento.Value.Year.ToString("0000"),
                    Email = retorno.Email,
                    Idcliente = retorno.Idcliente,
                    Numero = retorno.Numero,
                    Rgcliente = retorno.Rgcliente,
                    Telefonecelular = retorno.Telefonecelular,
                    Telefonefixo = retorno.Telefonefixo
                }
                );
            }
        }
        [HttpPost]
        public IActionResult AlterarCliente([FromBody] DTOs.Cliente cliente)
        {
            var retorno = clienteNegocio.AlterarCliente(cliente);
            if (clienteNegocio.erros.Count > 0)
            {
                return Ok(new { erros = clienteNegocio.erros });
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpGet]
        public IActionResult Entrar(string email, string senha)
        {
            var retorno = clienteNegocio.Entrar(email,senha);
            if (clienteNegocio.erros.Count > 0)
            {
                return Ok(new { erros = clienteNegocio.erros });
            }
            else
            {
                return Ok(new { idcliente = retorno.Idcliente });
            }
        }
    }
}