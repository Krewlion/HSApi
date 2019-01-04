using HSApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HSApi.Negocio
{
    public class Endereco : AbstractNegocio
    {
        public List<Cidades> ListarCidades(string cidade)
        {
            try
            {
                using (HSContext hs = new HSContext())
                {
                    return hs.Cidades.Where(x => x.DsCidadeNome.Contains(cidade)).ToList();
                }
            }
            catch (Exception ex)
            {
                erros.Add("Ocorreu um erro ao listar as cidades.");
                erros.Add(ex.Message);
                return null;
            }
        }

        public List<DTOs.Endereco> ListarBairros(string bairro)
        {
            List<DTOs.Endereco> final = new List<DTOs.Endereco>();
            try
            {
                using (HSContext hs = new HSContext())
                {
                        var enderecos = 
                        hs.Bairros.Include(x => x.CdCidadeNavigation).ThenInclude(x=>x.CdUfNavigation)
                        .Where(x => x.CdCidadeNavigation.DsCidadeNome.Contains(bairro))
                        .Select(x => new DTOs.Endereco() {
                            bairro = x.CdCidadeNavigation.DsCidadeNome,
                            cidade = x.CdCidadeNavigation.CdUfNavigation.DsUfNome,
                            cdbairro = 0,
                            cdcidade = x.CdCidadeNavigation.CdCidade,
                        }).Distinct().OrderBy(x=>x.cidade).ToList();
                    if (enderecos.Count() > 0) {
                        final.AddRange(
                                enderecos
                            );
                    };

                    final.AddRange(hs.Bairros.Include(x => x.CdCidadeNavigation).Where(x => x.DsBairroNome.Contains(bairro) || x.CdCidadeNavigation.DsCidadeNome.Contains(bairro)).Select(x => new DTOs.Endereco()
                    {
                        bairro = x.DsBairroNome,
                        cdbairro = x.CdBairro,
                        cdcidade = x.CdCidade,
                        cidade = x.CdCidadeNavigation.DsCidadeNome
                    }).OrderBy(x => x.cdcidade).ThenBy(x => x.cdbairro).ToList());

                    return final;
                }
            }
            catch (Exception ex)
            {
                erros.Add("Ocorreu um erro ao listar as cidades.");
                erros.Add(ex.Message);
                return null;
            }
        }
    }
}
