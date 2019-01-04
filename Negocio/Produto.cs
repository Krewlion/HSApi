using HSApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class Produto : AbstractNegocio
    {
        public bool IncluirProduto(DTOs.Produto produto)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    Tbproduto produtoAdd = new Tbproduto();
                    produtoAdd.Descricao = produto.descricao.ToUpper();
                    produtoAdd.Valor = decimal.Parse(produto.valor);
                    hs.Tbproduto.Add(produtoAdd);
                    hs.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erros.Add("O produto não foi adicionado.");
                erros.Add(ex.Message);
                return false;
            }
            return true;
        }

        public List<Tbproduto> AutoComplete(string nome)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return hs.Tbproduto.Where(x => x.Descricao.Contains(nome)).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao pesquisar produtos.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public Tbproduto Buscar(int idProduto)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return hs.Tbproduto.First(x => x.Idproduto == idProduto);
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao pesquisar produtos.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public bool AlterarProduto(DTOs.Produto produto)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var produtoAlterar = hs.Tbproduto.First(x => x.Idproduto == produto.idProduto);
                    produtoAlterar.Descricao = produto.descricao.ToUpper();
                    produtoAlterar.Valor = Decimal.Parse(produto.valor);
                    hs.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erros.Add("O produto não foi alterado.");
                erros.Add(ex.Message);
                return false;
            }
            return true;
        }
    }
}
