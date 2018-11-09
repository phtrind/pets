using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Pets;
using PetSaver.Repository.Anuncios;
using PetSaver.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSaver.Business.Anuncios
{
    public class AnuncioBusiness : BaseBusiness<AnuncioEntity, AnuncioRepository>
    {
        public IEnumerable<AnuncioMiniaturaResponse> ListarMiniaturas(FiltroAnuncioRequest aFiltro)
        {
            if (aFiltro == null)
            {
                aFiltro = new FiltroAnuncioRequest();
            }

            if (aFiltro.Quantidade == default)
            {
                aFiltro.Quantidade = 16;
            }

            if (aFiltro.Pagina == default)
            {
                aFiltro.Pagina = 1;
            }

            return PreencherObjetoMiniatura(new AnuncioRepository().BuscarAnuncios(aFiltro));
        }

        public IEnumerable<AnuncioMiniaturaResponse> ListarDestaquesMiniaturas()
        {
            return PreencherObjetoMiniatura(new AnuncioRepository().BuscarAnunciosDestaques());
        }

        public IEnumerable<AnuncioMiniaturaResponse> PreencherObjetoMiniatura(IEnumerable<dynamic> aLista)
        {
            return aLista.Select(x => new AnuncioMiniaturaResponse()
            {
                Nome = Convert.ToString(x.PET_NOME),
                Sexo = ((Sexos)Utilities.Conversor.IntParaEnum<Sexos>(Convert.ToInt32(x.PTS_CODIGO))).Traduzir(),
                Idade = ((Idades)Utilities.Conversor.IntParaEnum<Idades>(Convert.ToInt32(x.PID_CODIGO))).Traduzir(),
                Localizacao = $"{Convert.ToString(x.CID_NOME)} / {Convert.ToString(x.EST_SIGLA)}",
                Foto = Convert.ToString(x.ANF_LINK)
            });
        }
    }
}
