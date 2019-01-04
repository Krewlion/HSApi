using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class Login : AbstractNegocio
    {
        public EF.Tbusuario logar(DTOs.Usuario entrar)
        {
            try
            {
                byte[] theBytes = Encoding.ASCII.GetBytes(entrar.senha);
                using (EF.HSContext ef = new EF.HSContext())
                {
                    var resultado = ef.Tbusuario.FirstOrDefault(x => x.Loginusuario == entrar.loginusuario && x.Senha == theBytes);
                    if (resultado == null)
                    {
                        var login = ef.Tbusuario.FirstOrDefault(x => x.Loginusuario == entrar.loginusuario);
                        if (login == null)
                        {
                            this.erros.Add("O usuario digitado não está cadastrado: " + entrar.loginusuario);
                            return null;
                        }
                        else
                        {
                            this.erros.Add("A senha digitada não confere com a cadastrada para o usuário.");
                            return null;
                        }
                    }
                    else
                    {
                        return resultado;
                    }
                }


            }
            catch (Exception ex)
            {
                this.erros.Add(ex.Message);
                return null;
            }

        }
    }
}
