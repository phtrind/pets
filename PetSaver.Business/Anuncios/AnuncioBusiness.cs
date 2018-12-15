using PetSaver.Business.Localizacao;
using PetSaver.Business.Pets;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
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
                    IdStatus = Conversor.EnumParaInt(StatusAnuncio.EmAnalise), //TODO: quando for pra produção colocar para o anúncio iniciar em análise
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

                new AnuncioStatusHistoricoBusiness().Inserir(new AnuncioStatusHistoricoEntity()
                {
                    IdAnuncio = idAnuncio,
                    IdStatus = Conversor.EnumParaInt(StatusAnuncio.EmAnalise),
                    IdLoginCadastro = usuario.IdLogin
                });

                transaction.Complete();

                return idAnuncio;
            }
        }

        public void FinalizarAnuncio(FinalizarAnuncioRequest aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto de request é inválido.");
            }

            if (aRequest.IdLogin == default)
            {
                throw new BusinessException("O Id do login do usuário é inválido.");
            }

            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            if (aRequest.IdAnuncio == default)
            {
                throw new BusinessException("O Id do anúncio é inválido.");
            }

            var anuncio = Listar(aRequest.IdAnuncio);

            if (anuncio.IdUsuario != aRequest.IdUsuario)
            {
                throw new BusinessException("O usuário informado não é o dono do anúncio.");
            }

            var usuario = new UsuarioBusiness().Listar(aRequest.IdUsuario);

            if (usuario == null || usuario.IdLogin != aRequest.IdLogin)
            {
                throw new BusinessException("O Id informado não corresponde ao usuário informado.");
            }

            if (aRequest.Status == "Finalizar")
            {
                anuncio.IdStatus = Conversor.EnumParaInt(StatusAnuncio.Finalizado);
            }
            else if (aRequest.Status == "Cancelar")
            {
                anuncio.IdStatus = Conversor.EnumParaInt(StatusAnuncio.Cancelado);
            }
            else
            {
                throw new BusinessException("O status informado é inválido.");
            }

            anuncio.IdLoginAlteracao = aRequest.IdLogin;
            anuncio.DataAlteracao = DateTime.Now;

            using (var transaction = new TransactionScope())
            {
                Atualizar(anuncio);

                new AnuncioStatusHistoricoBusiness().Inserir(new AnuncioStatusHistoricoEntity()
                {
                    IdAnuncio = anuncio.Id,
                    IdStatus = anuncio.IdStatus,
                    IdLoginCadastro = usuario.IdLogin
                });

                transaction.Complete();
            }

            new EmailBusiness().AlteracaoStatusAnuncio(new LoginBusiness().Listar(usuario.IdLogin).Email);

        }

        public void AtivarAnuncio()
        {
            //TODO: implementar ativação de anúncio e envio de email
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
                Id = Convert.ToInt32(retornoDb.USU_CODIGO),
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

            response.Duvidas = new DuvidaBusiness().BuscarPorAnuncio(aIdAnuncio);

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

        public IEnumerable<RelatorioAnunciosContract> ListarRelatorioAnuncios(RelatorioAnunciosRequest aRequest, TiposAnuncio? aTipoAnuncio)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto de request é inválido");
            }

            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido");
            }

            if (aRequest.Filtro == null)
            {
                aRequest.Filtro = new FiltroRelatorioAnunciosRequest();
            }

            if (aTipoAnuncio.HasValue)
            {
                aRequest.Filtro.TipoAnuncio = Conversor.EnumParaInt(aTipoAnuncio);
            }


            return new AnuncioRepository().ListarRelatorioAnuncios(aRequest.IdUsuario, aRequest.Filtro).Select(x => new RelatorioAnunciosContract()
            {
                IdAnuncio = Convert.ToInt32(x.ANU_CODIGO),
                TipoAnuncio = Convert.ToString(x.ANT_DESCRICAO),
                Nome = Convert.ToString(x.PET_NOME) ?? Constantes.Desconhecido,
                Animal = Convert.ToString(x.ANI_NOME) ?? Constantes.Indefinido,
                RacaEspecie = Convert.ToString(x.RAC_NOME) ?? Constantes.Indefinido,
                DataCadastro = Convert.ToDateTime(x.ANU_DTHCADASTRO).ToString("dd/MM/yyyy"),
                Status = Convert.ToString(x.ANS_DESCRICAO),
                Visualizacoes = Convert.ToInt32(x.VISUALIZACOES),
                Interessados = Convert.ToInt32(x.INTERESSADOS)
            });
        }

        /// <summary>
        /// Buscar favoritos por usuário
        /// </summary>
        /// <param name="aIdUsuario">Usuário</param>
        /// <returns></returns>
        public IEnumerable<AnuncioMiniaturaResponse> BuscarFavoritos(int aIdUsuario)
        {
            if (aIdUsuario == default || new UsuarioBusiness().Listar(aIdUsuario) == null)
            {
                throw new BusinessException("O Id do usuário é inválido");
            }

            return PreencherObjetoMiniatura(new AnuncioRepository().BuscarFavoritos(aIdUsuario));
        }

        public AnuncioEntity BuscarAnuncioPorInteresse(int aIdInteresse)
        {
            if (aIdInteresse == default)
            {
                return null;
            }

            var interesse = new InteresseBusiness().Listar(aIdInteresse);

            if (interesse == null)
            {
                return null;
            }

            return Listar(interesse.IdAnuncio);
        }

        public int QuantidadeAnunciosUsuario(int aIdUsuario)
        {
            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id do usuário informado é inválido.");
            }

            return new AnuncioRepository().ListarRelatorioAnuncios(aIdUsuario, null).Count();
        }

        public int QuantidadeFavoritosUsuario(int aIdUsuario)
        {
            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id do usuário informado é inválido.");
            }

            return new AnuncioRepository().BuscarFavoritos(aIdUsuario).Count();
        }

        public int QuantidadeAnunciosPorStatus(StatusAnuncio aStatus)
        {
            return new AnuncioRepository().QuantidadeAnunciosPorStatus(aStatus);
        }

        #endregion

        #region .: Utilitários :.

        public IEnumerable<ChaveValorContract> ComboTiposAnuncios()
        {
            return new List<ChaveValorContract>()
            {
                new ChaveValorContract()
                {
                    Chave = Conversor.EnumParaInt(TiposAnuncio.Doacao).ToString(),
                    Valor = "Doação"
                },
                new ChaveValorContract()
                {
                    Chave = Conversor.EnumParaInt(TiposAnuncio.PetEncontrado).ToString(),
                    Valor = "Pet encontrado"
                },
                new ChaveValorContract()
                {
                    Chave = Conversor.EnumParaInt(TiposAnuncio.PetPerdido).ToString(),
                    Valor = "Pet perdido"
                }
            }.OrderBy(x => x.Valor);
        }

        #endregion
    }
}
