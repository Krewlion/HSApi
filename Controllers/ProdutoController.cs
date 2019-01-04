using HSApi.EF;
using HSApi.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProdutoController : Controller
    {
        public Produto ProdutoNegocio = new Produto();

        public IActionResult IncluirProduto([FromBody] DTOs.Produto produto)
        {
            var retorno = ProdutoNegocio.IncluirProduto(produto);
            return Ok(retorno);
        }

        [HttpGet]
        public IActionResult AutoComplete(string nome)
        {
            var retorno = ProdutoNegocio.AutoComplete(nome);
            return Ok(retorno.Select(x => new { descricao = x.Descricao, idProduto = x.Idproduto, exibir = "ID: " + x.Idproduto + " - DESCRICAO: " + x.Descricao + " - VALOR: " + x.Valor }).ToList());
        }

        [HttpPost]
        public IActionResult BuscarProduto([FromBody] Tbproduto produto)
        {
            var retorno = ProdutoNegocio.Buscar(produto.Idproduto);
            return Ok(new { Descricao = retorno.Descricao, Valor = retorno.Valor.ToString().Replace(".", ","), Idproduto = retorno.Idproduto });
        }

        [HttpPost]
        public IActionResult AlterarProduto([FromBody] DTOs.Produto produto)
        {
            var retorno = ProdutoNegocio.AlterarProduto(produto);
            return Ok(retorno);
        }

    }
}
