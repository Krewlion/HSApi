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

        public DTOs.Usuario PegarDadosUsuario(string idusuariocripto)
        {
            try
            {
                var idusuario = this.Decrypt(idusuariocripto);

                using (HSContext hs = new HSContext())
                {
                    return hs.Tbusuario.Where(x => x.Idusuario == Int32.Parse(idusuario))
                        .Select(x => new DTOs.Usuario() {
                            email = x.Email,
                            datanascimento = x.Datanascimento.ToShortDateString(),
                            cpf = x.Cpf,
                            loginusuario = x.Loginusuario,
                            nomeusuario = x.Nomeusuario,
                            cartoes = hs.Tbusuariocartao.Where(cartao => cartao.Idusuario == x.Idusuario)
                            .Select(cartao => new DTOs.CartaoUsuario()
                            {
                                cvv = cartao.Cvv,
                                datavencimento = cartao.Datavencimento,
                                nomecartao = cartao.Nomecartao,
                                numerocartao = cartao.Numerocartao
                            }).ToList(),
                            reservas = hs.Tbreserva.Where(res => res.Idusuario == Int32.Parse(idusuario))
                            .Select(res => new DTOs.Reserva()
                            {
                                dataentrada = res.Dataentrada.Value.ToShortDateString(),
                                datasaida = res.Datasaida.Value.ToShortDateString(),
                                hotel = res.IdquartoNavigation.IdtipoquartoNavigation.IdempresaNavigation.Nomeempresa,
                                tipoquarto = res.IdquartoNavigation.IdtipoquartoNavigation.Tipoquarto,
                                valor = res.Valor.ToString()
                            }).ToList()
                        }).FirstOrDefault();

                }
            }
            catch(Exception ex)
            {
                this.erros.Add("Aconteceu um erro ao listar os seus cartões de crédito");
                this.erros.Add(ex.Message);
            }

            return null;
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

        public Tbusuariocartao IncluirCartaoUsuario(DTOs.CartaoUsuario cartao)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {

                    var idusuario = this.Decrypt(cartao.idusuariocripto);
                    Tbusuariocartao cartaoInserir = new Tbusuariocartao() {
                        Cvv = cartao.cvv,
                        Datavencimento = cartao.datavencimento,
                        Numerocartao = cartao.numerocartao,
                        Idusuario = Int32.Parse(idusuario),
                        Nomecartao = cartao.nomecartao
                    };


                    hs.Tbusuariocartao.Add(cartaoInserir);
                    hs.SaveChanges();

                    return cartaoInserir;
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
