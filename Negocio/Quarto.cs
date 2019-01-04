using HSApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class Quarto : AbstractNegocio
    {
        public bool IncluirQuarto(DTOs.Quarto quarto)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    Tbquarto quartoAdd = new Tbquarto();
                    quartoAdd.Quarto = quarto.quarto.ToUpper();
                    quartoAdd.Status = 1;
                    quartoAdd.Varanda = quarto.varanda;
                    quartoAdd.Camasolteiro = quarto.camasolteiro;
                    quartoAdd.Camacasal = quarto.camacasal;
                    quartoAdd.Arcondicionado = quarto.arcondicionado;
                    quartoAdd.Valor = decimal.Parse(quarto.valor);
                    hs.Tbquarto.Add(quartoAdd);
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

        public List<Tbquarto> AutoComplete(string nome)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return hs.Tbquarto.Where(x => x.Quarto.Contains(nome)).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao pesquisar o quarto.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public Tbquarto Buscar(int idQuarto)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {

                    return hs.Tbquarto.First(x => x.Idquarto == idQuarto);
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao pesquisar o quarto.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public List<Tbquarto> ListarTodosQuartosParaAlugar()
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return hs.Tbquarto.Where(x => x.Status == 1).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao listar os quartos para alugar.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public bool AlterarQuarto(DTOs.Quarto quarto)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    var quartoAlterar = hs.Tbquarto.First(x => x.Idquarto == quarto.idquarto);
                    quartoAlterar.Quarto = quarto.quarto.ToUpper();
                    quartoAlterar.Valor = Decimal.Parse(quarto.valor);
                    quartoAlterar.Arcondicionado = quarto.arcondicionado;
                    quartoAlterar.Camacasal = quarto.camacasal;
                    quartoAlterar.Camasolteiro = quarto.camasolteiro;
                    quartoAlterar.Varanda = quarto.varanda;
                    hs.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erros.Add("O quarto não foi alterado.");
                erros.Add(ex.Message);
                return false;
            }
            return true;
        }

    }
}
