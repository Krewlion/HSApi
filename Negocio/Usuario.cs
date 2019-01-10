using HSApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class Usuario : AbstractNegocio
    {
        public bool IncluirUsuario(DTOs.Usuario usuario)
        {
            try
            {
                byte[] theBytes = Encoding.ASCII.GetBytes(usuario.senha);
                using (HSContext hs = new HSContext())
                {
                    Tbusuario UsuarioAdd = new Tbusuario();
                    UsuarioAdd.Cpf = usuario.cpf;
                    UsuarioAdd.Datanascimento = DateTime.Parse(usuario.datanascimento);
                    UsuarioAdd.Email = usuario.email;
                    UsuarioAdd.Loginusuario = usuario.loginusuario;
                    UsuarioAdd.Nomeusuario = usuario.nomeusuario;
                    UsuarioAdd.Senha = theBytes;
                    hs.Tbusuario.Add(UsuarioAdd);
                    hs.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erros.Add("O quarto não foi adicionado.");
                erros.Add(ex.Message);
                return false;
            }
            return true;
        }

        public List<DTOs.CartaoUsuario> ListarCartoesUsuario(string idusuariocript)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {

                    var idusuario = this.Decrypt(idusuariocript);
                    return hs.Tbusuariocartao.Where(x => x.Idusuario == Int32.Parse(idusuario))
                        .Select(x => new DTOs.CartaoUsuario()
                        {
                            cvv = x.Cvv,
                            datavencimento = x.Datavencimento.ToString(),
                            idusuario = x.Idusuario,
                            idusuariocartao = x.Idusuariocartao,
                            nomecartao = x.Nomecartao,
                            numerocartao = x.Numerocartao
                        }
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("O quarto não foi adicionado.");
                erros.Add(ex.Message);
                return null;
            }
        }

    }
}
