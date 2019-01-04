using HSApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class Cliente : AbstractNegocio
    {
        public bool IncluirCliente(DTOs.Cliente cliente)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var existe = hs.Tbcliente.FirstOrDefault(x => x.Cpf == cliente.cpf.Replace(".", "").Replace("-", ""));
                    if (existe == null)
                    {
                        var data = DateTime.Parse(cliente.datanascimento);
                        Tbcliente clienteAdd = new Tbcliente();
                        clienteAdd.Nomecliente = cliente.nomeCliente.ToUpper();
                        clienteAdd.Cpf = cliente.cpf.Replace(".", "").Replace("-", "");
                        clienteAdd.Cep = cliente.cep.Replace("-", "");
                        clienteAdd.Complemento = cliente.complemento.ToUpper();
                        clienteAdd.Datanascimento = DateTime.Parse(cliente.datanascimento);
                        clienteAdd.Email = cliente.email.ToUpper();
                        clienteAdd.Numero = cliente.numero.ToUpper();
                        clienteAdd.Rgcliente = cliente.rgcliente.ToUpper();
                        clienteAdd.Telefonecelular = cliente.telefonecelular.Replace("-", "").Replace("(", "").Replace(")", "");
                        clienteAdd.Telefonefixo = cliente.telefonefixo.Replace("-", "").Replace("(", "").Replace(")", "");
                        hs.Tbcliente.Add(clienteAdd);
                        hs.SaveChanges();
                    }
                    else
                    {
                        erros.Add("O cliente não foi adicionado.");
                        erros.Add("Já existe um cliente cadastrado para o CPF digitado.");
                    }
                }
            }
            catch (Exception ex)
            {
                erros.Add("O cliente não foi adicionado.");
                erros.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    inner.Add(ex.InnerException.Message);
                }
                return false;
            }
            return true;
        }

        public bool AlterarCliente(DTOs.Cliente cliente)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var existe = hs.Tbcliente.FirstOrDefault(x => x.Cpf == cliente.cpf.Replace(".", "").Replace("-", "") && x.Idcliente != cliente.idcliente);
                    if (existe == null)
                    {
                        var alterar = hs.Tbcliente.First(x => x.Idcliente == cliente.idcliente);
                        alterar.Nomecliente = cliente.nomeCliente.ToUpper();
                        alterar.Cpf = cliente.cpf.Replace(".", "").Replace("-", "");
                        alterar.Cep = cliente.cep.Replace("-", "");
                        alterar.Complemento = cliente.complemento.ToUpper();
                        alterar.Datanascimento = DateTime.Parse(cliente.datanascimento);
                        alterar.Email = cliente.email.ToUpper();
                        alterar.Numero = cliente.numero.ToUpper();
                        alterar.Rgcliente = cliente.rgcliente.ToUpper();
                        alterar.Telefonecelular = cliente.telefonecelular.Replace("-", "").Replace("(", "").Replace(")", "");
                        alterar.Telefonefixo = cliente.telefonefixo.Replace("-", "").Replace("(", "").Replace(")", "");
                        hs.SaveChanges();
                        return true;
                    }
                    else
                    {
                        erros.Add("O cliente não foi alterado.");
                        erros.Add("Já existe um cliente cadastrado para o CPF digitado.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                erros.Add("O cliente não foi alterado.");
                erros.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    inner.Add(ex.InnerException.Message);
                }
                return false;
            }
        }

        public List<Tbcliente> AutoComplete(string nome)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return hs.Tbcliente.Where(x => x.Nomecliente.Contains(nome) || x.Cpf.Contains(nome)).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao pesquisar o cliente.");
                erros.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    inner.Add(ex.InnerException.Message);
                }
                return null;
            }
        }

        public Tbcliente Buscar(int idcliente)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return hs.Tbcliente.First(x => x.Idcliente == idcliente);
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao pesquisar o cliente.");
                erros.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    inner.Add(ex.InnerException.Message);
                }
                return null;
            }
        }

        public Tbcliente Entrar(string email, string senha)
        {
            try
            {
                byte[] theBytes = Encoding.ASCII.GetBytes(senha);

                using (HSContext hs = new HSContext())
                {
                    var retorno = hs.Tbcliente.FirstOrDefault(x => x.Email== email && x.Senha == theBytes);
                    if (retorno == null)
                    {
                        this.erros.Add("Usuario ou senha incorretos.");
                        return null;
                    }
                    else
                    {
                        return retorno;
                    }
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao pesquisar o cliente.");
                erros.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    inner.Add(ex.InnerException.Message);
                }
                return null;
            }
        }

    }
}
