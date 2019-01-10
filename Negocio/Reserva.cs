using HSApi.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class Reserva : AbstractNegocio
    {
        public List<DTOs.Empresa_Quartos> PesquisarQuartosSemReserva(string datas, int cdcidade, int cdbairro, string nomehotel, string hospedes)
        {

            List<DTOs.Empresa_Quartos> ResultadoFinal = new List<DTOs.Empresa_Quartos>();
            try
            {
                var datasSplit = datas.Split(",");
                DateTime inicial = DateTime.Parse(datasSplit[0].Substring(4,11));
                DateTime final = DateTime.Parse(datasSplit[1].Substring(4, 11));
                int qtdhospede = Int32.Parse(hospedes);
                using (HSContext hs = new HSContext())
                {


                    var ceps = hs.Logradouros
                        .Include(x => x.CdBairroNavigation)
                        .ThenInclude(x => x.CdCidadeNavigation)
                        .ThenInclude(x => x.CdUfNavigation)
                        .Where(x => x.CdBairroNavigation.CdCidade == cdcidade && cdbairro != 0 ? x.CdBairro == cdbairro : x.CdBairroNavigation.CdCidade == cdcidade )
                        .Select(x => x.NoLogradouroCep).ToList();

                    if (nomehotel == null)
                    {
                        nomehotel = "";
                    }

                    var retorno =
                        (
                            from quarto in hs.Tbquarto.Include(x => x.IdtipoquartoNavigation).ThenInclude(x=>x.IdempresaNavigation)
                            join reserva in hs.Tbreserva on quarto.Idquarto equals reserva.Idquarto into LeftJoin
                            from left in LeftJoin.DefaultIfEmpty()
                            where
                            (
                                (left.Datafinalizacao.HasValue || left == null)
                                ||
                                (!left.Datafinalizacao.HasValue && left.Datasaida < inicial)
                            )
                            select new DTOs.Quarto()
                            {
                                hotel = quarto.IdtipoquartoNavigation.IdempresaNavigation.Nomeempresa,
                                nomeempresa =
                                quarto.IdtipoquartoNavigation.IdempresaNavigation.Nomeempresa + " - " + hs.Logradouros
                                .Include(x => x.CdBairroNavigation)
                                .ThenInclude(x => x.CdCidadeNavigation)
                                .First(x => x.NoLogradouroCep == quarto.IdtipoquartoNavigation.IdempresaNavigation.Cep).CdBairroNavigation.DsBairroNome.ToUpper(),
                                idquarto = quarto.Idquarto,
                                valor = quarto.IdtipoquartoNavigation.Valor.ToString(),
                                andar = quarto.Andar,
                                idtipoquarto = quarto.Idtipoquarto,
                                quarto = quarto.Quarto,
                                varanda = quarto.IdtipoquartoNavigation.Varanda,
                                arcondicionado = quarto.IdtipoquartoNavigation.Arcondicionado,
                                camacasal = quarto.IdtipoquartoNavigation.Camacasal,
                                camasolteiro = quarto.IdtipoquartoNavigation.Camasolteiro,
                                cep = quarto.IdtipoquartoNavigation.IdempresaNavigation.Cep,
                                status = quarto.Status.Value,
                                ventilador = quarto.IdtipoquartoNavigation.Ventilador,
                                idempresa = quarto.IdtipoquartoNavigation.Idempresa,
                                banheiroprivativo = quarto.IdtipoquartoNavigation.Banheiroprivativo,
                                tipoquarto = quarto.IdtipoquartoNavigation.Tipoquarto,
                                endereco = hs.Logradouros
                                .Include(x => x.CdBairroNavigation)
                                .ThenInclude(x => x.CdCidadeNavigation)
                                .First(x => x.NoLogradouroCep == quarto.IdtipoquartoNavigation.IdempresaNavigation.Cep).DsLogradouroNome + " n° " + quarto.IdtipoquartoNavigation.IdempresaNavigation.Numero + " - Complemento " + quarto.IdtipoquartoNavigation.IdempresaNavigation.Complemente,
                                imagens = hs.Tbquartofoto.Where(x=>x.Idquarto == quarto.Idquarto).Select(x=>x.Imagem).ToList(),
                                foto = hs.Tbquartofoto.FirstOrDefault(x => x.Idquarto == quarto.Idquarto) == null ? "" : hs.Tbquartofoto.First(x => x.Idquarto == quarto.Idquarto).Imagem,
                                checkin = quarto.IdtipoquartoNavigation.IdempresaNavigation.Horachekin,
                                checkout = quarto.IdtipoquartoNavigation.IdempresaNavigation.Horacheckout,
                                qtdhospedes = quarto.IdtipoquartoNavigation.Totalpessoas,
                                banheira = quarto.IdtipoquartoNavigation.Banheira,
                                vistamar = quarto.IdtipoquartoNavigation.Vistamar,
                                vistapordosol = quarto.IdtipoquartoNavigation.Vistapordosol
                            }
                        )
                    .Distinct().Where(x=>ceps.Contains(x.cep) && x.qtdhospedes == qtdhospede).ToList();

                    if (nomehotel == "")
                    {
                        ResultadoFinal = (
                            from agru in retorno
                            group agru by new { agru.idempresa, agru.nomeempresa } into agrup
                            select new DTOs.Empresa_Quartos()
                            {
                                idempresa = agrup.Key.idempresa,
                                nomeempresa = agrup.Key.nomeempresa,
                                tipoquartos = retorno
                                .Where(x => x.idempresa == agrup.Key.idempresa)
                                .Select(x => new DTOs.TipoQuarto()
                                {
                                    tipoquarto = x.tipoquarto,
                                    idtipoquarto = x.idtipoquarto,
                                    valor = x.valor.ToString(),
                                    varanda = x.varanda,
                                    arcondicionado = x.arcondicionado,
                                    camacasal = x.camacasal,
                                    camasolteiro = x.camasolteiro,
                                    ventilador = x.ventilador,
                                    banheiroprivativo = x.banheira,
                                    qtdhospedes = x.qtdhospedes,
                                    banheira = x.banheira,
                                    vistamar = x.vistamar,
                                    vistapordosol = x.vistapordosol,
                                    quartos = retorno.Where(ret => ret.idtipoquarto == x.idtipoquarto && ret.qtdhospedes == qtdhospede).ToList()
                                }).Distinct().ToList()
                            }
                        ).ToList();
                    }
                    else
                    {
                        ResultadoFinal = (
                            from agru in retorno
                            group agru by new { agru.idempresa, agru.nomeempresa } into agrup
                            select new DTOs.Empresa_Quartos()
                            {
                                idempresa = agrup.Key.idempresa,
                                nomeempresa = agrup.Key.nomeempresa,
                                tipoquartos = retorno
                                .Where(x => x.idempresa == agrup.Key.idempresa)
                                .Select(x => new DTOs.TipoQuarto()
                                {
                                    tipoquarto = x.tipoquarto,
                                    idtipoquarto = x.idtipoquarto,
                                    valor = x.valor.ToString(),
                                    varanda = x.varanda,
                                    arcondicionado = x.arcondicionado,
                                    camacasal = x.camacasal,
                                    camasolteiro = x.camasolteiro,
                                    ventilador = x.ventilador,
                                    banheiroprivativo = x.banheira,
                                    qtdhospedes = x.qtdhospedes,
                                    banheira = x.banheira,
                                    vistamar = x.vistamar,
                                    vistapordosol = x.vistapordosol,
                                    quartos = retorno.Where(ret => ret.idtipoquarto == x.idtipoquarto && ret.qtdhospedes == qtdhospede).ToList()
                                }).Distinct().ToList()
                            }
                        ).ToList();
                    }

                    return ResultadoFinal;
                }
            }
            catch (Exception ex)
            {
                erros.Add("Os quartos para reserva não foram pesquisados. Ocorreu um erro.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public bool IncluirReserva(DTOs.Reserva reserva)
        {
            try
            {
                var idcliente = this.Decrypt(reserva.idusuariocripto);
                using (HSContext hs = new HSContext())
                {

                    var podeCadastrar = hs.Tbreserva
                        .Where
                        (
                            x =>
                            (
                                (x.Dataentrada >= DateTime.Parse(reserva.dataentrada) && x.Datasaida <= DateTime.Parse(reserva.dataentrada))
                                    ||
                                (x.Datasaida <= DateTime.Parse(reserva.datasaida))
                            )
                                &&
                            (x.Idquarto == reserva.idquarto)

                        ).ToList();

                    if (podeCadastrar.Count() > 0)
                    {
                        this.erros.Add("Infelizmente esse quarto já foi reservado.");
                        this.erros.Add("Escolha outro quarto.");
                        return false;
                    }

                    Tbreserva reservaAdd = new Tbreserva();

                    reservaAdd.Idquarto = reserva.idquarto;
                    reservaAdd.Idusuario = Int32.Parse(idcliente);
                    reservaAdd.Valor = Decimal.Parse(reserva.valor.Replace(".", ","));
                    reservaAdd.Checkout = false;
                    reservaAdd.Dataentrada = DateTime.Parse(reserva.dataentrada);
                    reservaAdd.Datasaida = DateTime.Parse(reserva.datasaida);
                    reservaAdd.Datacadastro = DateTime.Now;
                    hs.Tbreserva.Add(reservaAdd);
                    hs.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erros.Add("A reserva não foi adicionada.");
                erros.Add(ex.Message);
                return false;
            }
            return true;
        }

        public List<DTOs.Reserva> ListarReservasAtivas()
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return
                        (
                            from reserva in hs.Tbreserva
                            join quarto in hs.Tbquarto on reserva.Idquarto equals quarto.Idquarto
                            join usuario in hs.Tbusuario on reserva.Idusuario equals usuario.Idusuario
                            where !reserva.Datafinalizacao.HasValue
                            orderby reserva.Dataentrada
                            select new DTOs.Reserva()
                            {
                                idreserva = reserva.Idreserva,
                                nomecliente = usuario.Nomeusuario,
                                quarto = quarto.Quarto,
                                valor = reserva.Valor.ToString(),
                                dataentrada = reserva.Dataentrada.Value.ToString("dd/MM/yyyy"),
                                datasaida = reserva.Datasaida.Value.ToString("dd/MM/yyyy"),
                                cpf = usuario.Cpf,
                                checkout = reserva.Checkout.Value
                            }

                        ).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Ocorreu um erro ao pesquisar as reservas ativas.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public bool CheckOut(int idreserva)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var reserva = hs.Tbreserva.First(x => x.Idreserva == idreserva);
                    reserva.Checkout = true;
                    hs.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                erros.Add("O checkout não foi realizado.");
                erros.Add(ex.Message);
                return false;
            }
        }

        public DTOs.Reserva BuscarReservaPeloID(int idreserva)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return
                     (
                         from reserva in hs.Tbreserva
                         join quarto in hs.Tbquarto on reserva.Idquarto equals quarto.Idquarto
                         join usuario in hs.Tbusuario on reserva.Idusuario equals usuario.Idusuario
                         where reserva.Idreserva == idreserva
                         select new DTOs.Reserva()
                         {
                             idreserva = reserva.Idreserva,
                             checkout = reserva.Checkout.Value,
                             cpf = usuario.Cpf,
                             nomecliente = usuario.Nomeusuario,
                             quarto = quarto.Quarto,
                             valor = reserva.Valor.ToString(),
                             dataentrada = reserva.Dataentrada.Value.ToString("dd/MM/yyyy"),
                             datasaida = reserva.Datasaida.Value.ToString("dd/MM/yyyy")
                         }
                 ).First();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Ocorreu um erro ao pesquisar a reserva pelo ID.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public DTOs.Reserva BuscarReservaComCheckoutPeloID(int idreserva)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return
                     (
                         from reserva in hs.Tbreserva
                         join quarto in hs.Tbquarto on reserva.Idquarto equals quarto.Idquarto
                         join usuario in hs.Tbusuario on reserva.Idusuario equals usuario.Idusuario
                         where reserva.Idreserva == idreserva
                         select new DTOs.Reserva()
                         {
                             idreserva = reserva.Idreserva,
                             checkout = reserva.Checkout.Value,
                             valorcheckout = hs.Tbprodutoreserva.Where(x => x.Idreserva == idreserva).Sum(x => x.Valor * x.Quantidade).ToString(),
                             cpf = usuario.Cpf,
                             nomecliente = usuario.Nomeusuario,
                             quarto = quarto.Quarto,
                             valor = reserva.Valor.ToString(),
                             dataentrada = reserva.Dataentrada.Value.ToString("dd/MM/yyyy"),
                             datasaida = reserva.Datasaida.Value.ToString("dd/MM/yyyy")
                         }
                 ).First();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Ocorreu um erro ao pesquisar a reserva pelo ID.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public bool RealizarPagamento(DTOs.Pagamento pagamento)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {

                    var reserva = hs.Tbreserva.First(x => x.Idreserva == pagamento.idreserva);

                    var totalPagamentos = hs.Tbpagamento.Where(x => x.Idreserva == pagamento.idreserva).Sum(x => x.Valor);

                    var totalDividaCheckout = hs.Tbprodutoreserva.Where(x => x.Idreserva == pagamento.idreserva).Sum(x => x.Valor * x.Quantidade);

                    var totalPagamentoComCheckout = reserva.Valor + totalDividaCheckout;

                    if (totalPagamentos + decimal.Parse(pagamento.valor) > totalPagamentoComCheckout)
                    {
                        erros.Add("Não pode ser adicionado esse pagamento, porque o valor fica superior ao devido pelo cliente.");
                        return false;
                    }
                    else
                    {
                        Tbpagamento pagamentoAdd = new Tbpagamento();
                        pagamentoAdd.Idreserva = pagamento.idreserva;
                        pagamentoAdd.Datapagamento = DateTime.Now;
                        pagamentoAdd.Valor = Decimal.Parse(pagamento.valor);
                        pagamentoAdd.Chavepagamento = pagamento.chavepagamento;
                        pagamentoAdd.Idtipopagamento = pagamento.idtipopagamento;
                        hs.Tbpagamento.Add(pagamentoAdd);
                        hs.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                erros.Add("O pagamento não foi inserido.");
                erros.Add(ex.Message);
                return false;
            }
        }

        public bool RemoverPagamento(int idpagamento)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var pagamento = hs.Tbpagamento.First(x => x.Idpagamento == idpagamento);
                    hs.Tbpagamento.Remove(pagamento);
                    hs.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                erros.Add("A exclusão do pagamento não foi realiada.");
                erros.Add(ex.Message);
                return false;
            }
        }

        public List<DTOs.Pagamento> ListarPagamentosPeloIDreserva(int idreserva)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return (
                        from paga in hs.Tbpagamento
                        join tipo in hs.Tbtipopagamento on paga.Idtipopagamento equals tipo.Idtipopagamento
                        where paga.Idreserva == idreserva
                        select new DTOs.Pagamento()
                        {
                            idtipopagamento = paga.Idtipopagamento,
                            idreserva = paga.Idreserva,
                            valor = paga.Valor.ToString(),
                            chavepagamento = paga.Chavepagamento,
                            idpagamento = paga.Idpagamento,
                            tipopagamento = tipo.Tipopagamento,
                            datapagamento = paga.Datapagamento.Value.ToString("dd/MM/yyyy")
                        }
                        ).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Os pagamentos não foram listados.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public List<DTOs.produtosReserva> ListarProdutosPorReserva(int idreserva)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return (
                            from produtoreserva in hs.Tbprodutoreserva
                            join produto in hs.Tbproduto on produtoreserva.Idproduto equals produto.Idproduto
                            where produtoreserva.Idreserva == idreserva
                            select new DTOs.produtosReserva()
                            {
                                idprodutocheckout = produtoreserva.Idprodutocheckout,
                                descricao = produto.Descricao,
                                idproduto = produto.Idproduto,
                                idreserva = produtoreserva.Idreserva.Value,
                                quantidade = produtoreserva.Quantidade.Value,
                                valor = produtoreserva.Valor.ToString()
                            }
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Não foi possível listar os produtos dessa reserva.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public bool AdicionarProdutosReservaCheckout(DTOs.Reserva reserva)
        {
            List<DTOs.produtosReserva> produtos = reserva.produtos;
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var produtosdaReserva = hs.Tbprodutoreserva.Where(x => x.Idreserva == reserva.idreserva).ToList();
                    var idprodutoscheckout = produtosdaReserva.Select(x => x.Idprodutocheckout).ToList();
                    var idprodutoscheckoutReserva = produtos.Select(x => x.idprodutocheckout).ToList();

                    var idsParaDeletar = idprodutoscheckout.Except(idprodutoscheckoutReserva.Where(x => x != 0)).ToList();

                    var produtosDeletados = hs.Tbprodutoreserva.Where(x => idsParaDeletar.Contains(x.Idprodutocheckout)).ToList();

                    var reservaAtual = hs.Tbreserva.First(x => x.Idreserva == reserva.idreserva);
                    reservaAtual.Checkout = true;
                    if (produtos.Count > 0)
                    {
                        foreach (var item in produtos)
                        {
                            if (item.idprodutocheckout == 0)
                            {
                                hs.Tbprodutoreserva
                                    .Add(new Tbprodutoreserva()
                                    {
                                        Idproduto = item.idproduto,
                                        Idreserva = item.idreserva,
                                        Quantidade = item.quantidade,
                                        Valor = decimal.Parse(item.valor.Replace(".", ","))
                                    });
                            }
                            else
                            {
                                var produtoreserva = hs.Tbprodutoreserva.First(x => x.Idprodutocheckout == item.idprodutocheckout);
                                produtoreserva.Quantidade = item.quantidade;
                                produtoreserva.Valor = decimal.Parse(item.valor.Replace(".", ","));
                            }
                        }

                        foreach (var item in produtosDeletados)
                        {
                            hs.Tbprodutoreserva.Remove(item);
                        }

                        hs.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                erros.Add("Produtos do checkout não inseridos.");
                erros.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    erros.Add(ex.InnerException.Message);
                }
                return false;
            }
        }

        public bool FinalizarReserva(DTOs.Reserva reserva)
        {
            List<DTOs.produtosReserva> produtos = reserva.produtos;
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var finalizar = hs.Tbreserva.First(x => x.Idreserva == reserva.idreserva);


                    var valorcheckout = hs.Tbprodutoreserva.Where(x => x.Idreserva == reserva.idreserva).Sum(x => x.Valor * x.Quantidade);
                    var valorpagamento = hs.Tbpagamento.Where(x => x.Idreserva == reserva.idreserva).Sum(x => x.Valor);

                    var totalPagamentoComCheckout = valorcheckout + valorpagamento;

                    if (finalizar.Checkout == false)
                    {
                        erros.Add("Não foi possível finalizar a reserva.");
                        erros.Add("O checkout dessa reserva ainda não foi realizado.");
                    }
                    else
                    {

                        if (valorpagamento == 0)
                        {
                            erros.Add("Não foi possível finalizar a reserva.");
                            erros.Add("Não foi identificado nenhum pagamento para a reserva.");
                        }
                        else
                        {
                            if ((finalizar.Valor + valorcheckout) > valorpagamento)
                            {
                                erros.Add("Não foi possível finalizar a reserva.");
                                erros.Add("O pagamento da reserva não bateu com o total da reserva, verifique novamente o pagamento dessa reserva.");
                            }
                            else
                            {
                                finalizar.Datafinalizacao = DateTime.Now;
                                hs.SaveChanges();
                            }
                        }
                    }
                    return true;
                }

            }
            catch (Exception ex)
            {
                erros.Add("Reserva não finalizada.");
                erros.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    erros.Add(ex.InnerException.Message);
                }
                return false;
            }
        }

        public bool CancelarReserva(DTOs.Reserva reserva)
        {
            List<DTOs.produtosReserva> produtos = reserva.produtos;
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var cancelar = hs.Tbreserva.First(x => x.Idreserva == reserva.idreserva);

                    cancelar.Datacancelamento = DateTime.Now;
                    cancelar.Motivocancelamento = reserva.motivocancelamento;
                    hs.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                erros.Add("Reserva não foi cancelada.");
                erros.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    erros.Add(ex.InnerException.Message);
                }
                return false;
            }
        }
    }
}
