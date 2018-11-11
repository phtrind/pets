using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Paginas;
using PetSaver.Contracts.Paginas.Response.PetPage;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Pets;
using PetSaver.Exceptions;
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
                Foto = Convert.ToString(x.ANF_LINK),
                Tipo = Convert.ToString(x.ANT_DESCRICAO)
            });
        }

        public PetPageResponse AbrirAnuncio(int aIdAnuncio, int? aIdUsuario)
        {
            if (aIdAnuncio == default || Listar(aIdAnuncio) == null)
            {
                throw new BusinessException("O Id do anúncio é invalido.");
            }

            new AnuncioVisitaBusiness().GravarLog(aIdAnuncio, aIdUsuario);

            dynamic retornoDb = new AnuncioRepository().AbrirAnuncio(aIdAnuncio);

            if (retornoDb == null)
            {
                throw new BusinessException("O anúncio não foi encontrado.");
            }

            var response = new PetPageResponse();

            response.Anunciante = new AnuncianteContract()
            {
                Nome = Convert.ToString(retornoDb.USU_NOME),
                Avaliacao = new AvaliacaoBusiness().MediaAvaliacaoPorUsuario(Convert.ToInt32(retornoDb.USU_CODIGO))
            };

            response.Pet = new PetContract()
            {
                Nome = Convert.ToString(retornoDb.PET_NOME),
                RacaEspecie = retornoDb.RAC_NOME != null ? Convert.ToString(retornoDb.RAC_NOME) : null,
                Cidade = Convert.ToString(retornoDb.CID_NOME),
                Estado = Convert.ToString(retornoDb.EST_SIGLA),
                Sexo = retornoDb.SEXO != null ? Convert.ToString(retornoDb.SEXO) : null,
                Idade = retornoDb.IDADE != null ? Convert.ToString(retornoDb.IDADE) : null,
                Porte = retornoDb.PORTE != null ? Convert.ToString(retornoDb.PORTE) : null,
                Cores = new List<string>()
                {
                    Convert.ToString(retornoDb.COR_PRIMARIA),
                    retornoDb.COR_SECUNDARIA != null ? Convert.ToString(retornoDb.COR_SECUNDARIA) : null
                },
                Pelo = retornoDb.PELO != null ? Convert.ToString(retornoDb.PELO) : null,
                Vacinado = retornoDb.PET_VACINADO != null ? Convert.ToBoolean(retornoDb.PET_VACINADO) : null,
                Vermifugado = retornoDb.PET_VERMIFUGADO != null ? Convert.ToBoolean(retornoDb.PET_VERMIFUGADO) : null,
                Castrado = retornoDb.PET_CASTRADO != null ? Convert.ToBoolean(retornoDb.PET_CASTRADO) : null,
                Descricao = Convert.ToString(retornoDb.PET_DESCRICAO),
            };

            if (retornoDb.LOC_LATITUDE != null && retornoDb.LOC_LONGITUDE != null)
            {
                response.Localizacao = new LocalizacaoContract()
                {
                    Latitude = Convert.ToDouble(retornoDb.LOC_LATITUDE),
                    Longitude = Convert.ToDouble(retornoDb.LOC_LONGITUDE)
                };
            }

            response.StatusAnuncio = Convert.ToString(retornoDb.ANS_DESCRICAO);

            response.Duvidas = new DuvidaBusiness().BuscarPorAnuncio(aIdAnuncio);

            if (aIdUsuario.HasValue && aIdUsuario.Value != default)
            {
                response.Gostei = new AnuncioGosteiBusiness().UsuarioGostouAnuncio(aIdAnuncio, aIdUsuario.Value);
            }

            return response;
        }
    }
}
