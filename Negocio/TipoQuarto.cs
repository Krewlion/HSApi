using HSApi.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class TipoQuarto : AbstractNegocio
    {
        public List<DTOs.Quarto> Listar(int idempresa)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {

                    return hs.Tbquarto.Include(x => x.IdtipoquartoNavigation)
                        .ThenInclude(x=>x.IdempresaNavigation)
                        .Where(x => x.IdtipoquartoNavigation.IdempresaNavigation.Idempresa== idempresa)
                        .Select(x => new DTOs.Quarto()
                        {
                            tipoquarto = x.IdtipoquartoNavigation.Tipoquarto,
                            andar = x.Andar,
                            varanda = x.IdtipoquartoNavigation.Varanda,
                            quarto = x.Quarto,
                            idquarto = x.Idquarto,
                            arcondicionado = x.IdtipoquartoNavigation.Arcondicionado,
                            camacasal = x.IdtipoquartoNavigation.Camacasal,
                            camasolteiro = x.IdtipoquartoNavigation.Camasolteiro,
                            status = x.Status.Value,
                            valor = x.IdtipoquartoNavigation.Valor.ToString(),

                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Erro ao pesquisar o quarto.");
                erros.Add(ex.Message);
                return null;
            }
        }
    }
}
