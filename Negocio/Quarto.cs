using HSApi.EF;
using Microsoft.EntityFrameworkCore;
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
                    quartoAdd.Idtipoquarto = quarto.idtipoquarto;
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

        public DTOs.Quarto Buscar(int idQuarto)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {

                    return hs.Tbquarto.Include(x => x.IdtipoquartoNavigation).Where(x => x.Idquarto == idQuarto)
                        .Select(x => new DTOs.Quarto()
                        {
                            andar = x.Andar,
                            varanda = x.IdtipoquartoNavigation.Varanda,
                            quarto = x.Quarto,
                            idquarto = x.Idquarto,
                            arcondicionado = x.IdtipoquartoNavigation.Arcondicionado,
                            camacasal =x.IdtipoquartoNavigation.Camacasal,
                            camasolteiro = x.IdtipoquartoNavigation.Camasolteiro,
                            status = x.Status.Value,
                            valor = x.IdtipoquartoNavigation.Valor.ToString(),

                        }).First();
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
                    quartoAlterar.Idtipoquarto = quarto.idtipoquarto;
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
