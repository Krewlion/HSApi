using HSApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Negocio
{
    public class TipoPagamento : AbstractNegocio
    {
        public List<DTOs.TipoPagamento> ListarTiposDePagamento()
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return hs.Tbtipopagamento.Select(x => new DTOs.TipoPagamento() { idtipopagamento = x.Idtipopagamento, tipopagamento = x.Tipopagamento }).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Ocorreu um erro ao listar os tipos de pagamentos");
                erros.Add(ex.Message);
                return null;
            }
        }
    }
}
