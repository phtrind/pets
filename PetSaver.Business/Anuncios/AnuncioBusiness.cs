using PetSaver.Business.Localizacao;
using PetSaver.Business.Pets;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Paginas;
using PetSaver.Contracts.Paginas.Response.PetPage;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Entity.Enums.Tipos;
using PetSaver.Entity.Localizacao;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;
using PetSaver.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PetSaver.Business.Anuncios
{
    public class AnuncioBusiness : BaseBusiness<AnuncioEntity, AnuncioRepository>
    {
        #region .: Cadastros :.

        public int Cadastrar(CadastrarPetAnuncioRequest aRequest, TiposAnuncio aTipoAnuncio)
        {
            var usuario = new UsuarioBusiness().Listar(aRequest.IdUsuario);

            if (usuario == null)
            {
                throw new BusinessException("O usuário informado é inválido.");
            }

            if (aRequest.Anuncio == null)
            {
                throw new BusinessException("O objeto anúncio não pode ser nulo.");
            }

            if (aRequest.Anuncio.Pet == null)
            {
                throw new BusinessException("O objeto Pet não pode ser nulo.");
            }

            using (var transaction = new TransactionScope())
            {
                var idPet = new PetBusiness().Cadastrar(usuario.IdLogin, aRequest.Anuncio.Pet);

                var anuncio = new AnuncioEntity()
                {
                    IdLoginCadastro = usuario.IdLogin,
                    IdStatus = Conversor.EnumParaInt(StatusAnuncio.EmAnalise),
                    IdTipo = Conversor.EnumParaInt(aTipoAnuncio),
                    IdPet = idPet,
                    IdEstado = aRequest.Anuncio.IdEstado,
                    IdCidade = aRequest.Anuncio.IdCidade,
                    IdUsuario = aRequest.IdUsuario
                };

                if (aRequest.Anuncio.Localizacao != null &&
                    aRequest.Anuncio.Localizacao.Latitude != default &&
                    aRequest.Anuncio.Localizacao.Longitude != default)
                {
                    anuncio.IdLocalizacao = new LocalizacaoBusiness().Inserir(new LocalizacaoEntity()
                    {
                        IdLoginCadastro = usuario.IdLogin,
                        Latitude = aRequest.Anuncio.Localizacao.Latitude,
                        Longitude = aRequest.Anuncio.Localizacao.Longitude
                    });
                }

                var idAnuncio = Inserir(anuncio);

                new AnuncioFotoBusiness().Cadastrar(idAnuncio,
                                                    usuario.IdLogin,
                                                    aRequest.Anuncio.GuidImagens);

                transaction.Complete();

                return idAnuncio;
            }
        }

        #endregion

        #region .: Buscas :.

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

            return PreencherObjetoMiniatura(new AnuncioRepository().BuscarAnunciosAtivos(aFiltro));
        }

        public IEnumerable<AnuncioMiniaturaResponse> ListarDestaquesMiniaturas()
        {
            return PreencherObjetoMiniatura(new AnuncioRepository().BuscarAnunciosDestaques());
        }

        public IEnumerable<AnuncioMiniaturaResponse> PreencherObjetoMiniatura(IEnumerable<dynamic> aLista)
        {
            return aLista.Select(x => new AnuncioMiniaturaResponse()
            {
                IdAnuncio = Convert.ToInt32(x.ANU_CODIGO),
                Nome = string.IsNullOrEmpty(Convert.ToString(x.PET_NOME)) ? Constantes.Desconhecido : Convert.ToString(x.PET_NOME),
                Sexo = Convert.ToString(x.PTS_DESCRICAO) ?? Constantes.Indefinido,
                Idade = Convert.ToString(x.PID_DESCRICAO) ?? Constantes.Indefinido,
                Localizacao = $"{Convert.ToString(x.CID_NOME)} / {Convert.ToString(x.EST_SIGLA)}",
                Foto = AnuncioFotoBusiness.TratarCaminhoImagem(Convert.ToString(x.ANF_LINK)),
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
                Nome = string.IsNullOrEmpty(Convert.ToString(retornoDb.PET_NOME)) ? Constantes.Desconhecido : Convert.ToString(retornoDb.PET_NOME),
                RacaEspecie = retornoDb.RAC_NOME != null ? Convert.ToString(retornoDb.RAC_NOME) : Constantes.Indefinido,
                Cidade = Convert.ToString(retornoDb.CID_NOME),
                Estado = Convert.ToString(retornoDb.EST_SIGLA),
                Sexo = retornoDb.SEXO != null ? Convert.ToString(retornoDb.SEXO) : Constantes.Indefinido,
                Idade = retornoDb.IDADE != null ? Convert.ToString(retornoDb.IDADE) : Constantes.Indefinido,
                Porte = retornoDb.PORTE != null ? Convert.ToString(retornoDb.PORTE) : Constantes.Indefinido,
                Peso = retornoDb.PET_PESO != null ? $"{Convert.ToString(retornoDb.PET_PESO)} kg" : Constantes.Indefinido,
                Pelo = retornoDb.PELO != null ? Convert.ToString(retornoDb.PELO) : Constantes.Indefinido,
                Vacinado = retornoDb.PET_VACINADO != null ? Conversor.DbBooleanToString(retornoDb.PET_VACINADO) : Constantes.Indefinido,
                Vermifugado = retornoDb.PET_VERMIFUGADO != null ? Conversor.DbBooleanToString(retornoDb.PET_VERMIFUGADO) : Constantes.Indefinido,
                Castrado = retornoDb.PET_CASTRADO != null ? Conversor.DbBooleanToString(retornoDb.PET_CASTRADO) : Constantes.Indefinido,
                Descricao = Convert.ToString(retornoDb.PET_DESCRICAO),
            };

            response.Pet.Cor = Convert.ToString(retornoDb.COR_PRIMARIA);

            response.Pet.Fotos = new AnuncioFotoBusiness().BuscarPorAnuncioComDestaque(aIdAnuncio);

            if (retornoDb.COR_SECUNDARIA != null)
            {
                response.Pet.Cor += $" / {Convert.ToString(retornoDb.COR_SECUNDARIA)}";
            }

            if (retornoDb.LOC_LATITUDE != null && retornoDb.LOC_LONGITUDE != null)
            {
                response.Localizacao = new LocalizacaoContract()
                {
                    Latitude = Convert.ToDouble(retornoDb.LOC_LATITUDE),
                    Longitude = Convert.ToDouble(retornoDb.LOC_LONGITUDE)
                };
            }

            response.StatusAnuncio = Convert.ToString(retornoDb.ANS_DESCRICAO);

            response.TipoAnuncio = Convert.ToString(retornoDb.ANT_DESCRICAO);

            response.Duvidas = new DuvidaBusiness().BuscarPorAnuncio(aIdAnuncio).Where(x => !string.IsNullOrEmpty(x.Resposta));

            if (aIdUsuario.HasValue && aIdUsuario.Value != default)
            {
                response.Gostei = new AnuncioGosteiBusiness().UsuarioGostouAnuncio(aIdAnuncio, aIdUsuario.Value);

                if (Convert.ToInt32(retornoDb.USU_CODIGO) != aIdUsuario.Value &&
                    new InteresseBusiness().BuscarPorUsuarioAnuncio(aIdUsuario.Value, aIdAnuncio) == null)
                {
                    response.HabilitarAcoes = true;
                }
                else
                {
                    response.HabilitarAcoes = false;
                }
            }
            else
            {
                response.HabilitarAcoes = true;
            }

            return response;
        }

        public IEnumerable<RelatorioDoacoesContract> ListarRelatorioDoacoes(int aIdUsuario, FiltroRelatorioDoacoesRequest aFiltro)
        {
            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido");
            }

            FiltroRelatorioDoacoesRequest filtro;

            if (aFiltro == null)
            {
                filtro = new FiltroRelatorioDoacoesRequest();
            }
            else
            {
                filtro = aFiltro;
            }

            return new AnuncioRepository().ListarRelatorioDoacoes(aIdUsuario, aFiltro).Select(x => new RelatorioDoacoesContract()
            {
                IdAnuncio = Convert.ToInt32(x.ANU_CODIGO),
                Nome = Convert.ToString(x.PET_NOME),
                Animal = Convert.ToString(x.ANI_NOME),
                DataCadastro = Convert.ToDateTime(x.ANU_DTHCADASTRO).ToString("dd/MM/yyyy"),
                Status = Convert.ToString(x.ANS_DESCRICAO),
                Visualizacoes = Convert.ToInt32(x.VISUALIZACOES),
                Interessados = Convert.ToInt32(x.INTERESSADOS)
            });
        }

        #endregion
    }
}
