using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class Empresa : AbstractNegocio
    {
        public DTOs.Empresa BuscarEmpresa(int id)
        {
            try
            {
                using (EF.HSContext hs = new EF.HSContext())
                {
                    var empresa = hs.Tbempresa.FirstOrDefault(x=>x.Idempresa == id);
                    if (empresa != null)
                    {
                        return new DTOs.Empresa()
                        {
                            cep = empresa.Cep,
                            cnpj = empresa.Cnpj,
                            complemente = empresa.Complemente,
                            datacadastro = empresa.Datacadastro,
                            horacheckout = empresa.Horacheckout,
                            logradouro = hs.Logradouros.Where(x=>x.NoLogradouroCep == empresa.Cep).Select(x=>x.DsLogradouroNome.ToUpper()).First(),
                            horachekin = empresa.Horachekin,
                            idempresa = empresa.Idempresa,
                            nomeempresa = empresa.Nomeempresa,
                            numero = empresa.Numero,
                            razaosocial = empresa.Razaosocial
                        };
                    }
                    else
                    {
                        this.erros.Add("O ID não retornou nenhum dado, verifique se foi passado um paramêtro válido.");
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                this.erros.Add(ex.Message);
                return null;
            }
        }
    }
}
