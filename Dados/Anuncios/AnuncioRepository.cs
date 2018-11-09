using Dapper;
using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Entity.Enums.Tipos;
using PetSaver.Exceptions;
using PetSaver.Repository.Localizacao;
using PetSaver.Repository.Pets;
using PetSaver.Repository.Usuarios;
using PetSaver.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PetSaver.Repository.Anuncios
{
    public class AnuncioRepository : BaseRepository<AnuncioEntity>
    {
        protected override void ValidarAtributos(AnuncioEntity aObjeto)
        {
            if (!Enum.IsDefined(typeof(StatusAnuncio), aObjeto.IdStatus))
            {
                throw new DbValidationException("O Id do status do anúncio é inválido.");
            }

            if (!Enum.IsDefined(typeof(TiposAnuncio), aObjeto.IdTipo))
            {
                throw new DbValidationException("O Id do tipo do anúncio é inválido.");
            }

            if (aObjeto.IdPet == default || new PetRepository().Listar(aObjeto.IdPet) == null)
            {
                throw new DbValidationException("O Id do pet do anúncio é inválido.");
            }

            if (aObjeto.IdLocalizacao.HasValue)
            {
                if (aObjeto.IdLocalizacao == default)
                {
                    aObjeto.IdLocalizacao = null;
                }
                else if (new LocalizacaoRepository().Listar(aObjeto.IdLocalizacao.Value) == null)
                {
                    throw new DbValidationException("O Id da localização do anúncio é inválido.");
                }
            }

            if (aObjeto.IdEstado == default || new EstadoRepository().Listar(aObjeto.IdEstado) == null)
            {
                throw new DbValidationException("O Id do estado do anúncio é inválido.");
            }

            if (aObjeto.IdCidade == default)
            {
                throw new DbValidationException("O Id da cidade do anúncio é inválido.");
            }

            var cidade = new CidadeRepository().Listar(aObjeto.IdCidade);

            if (cidade == null)
            {
                throw new DbValidationException("O Id da cidade do anúncio é inválido.");
            }
            else if (cidade.IdEstado != aObjeto.IdEstado)
            {
                throw new DbValidationException("O Id da cidade não é referente ao Id do estado informado.");
            }

            if (aObjeto.IdUsuario == default || new UsuarioRepository().Listar(aObjeto.IdUsuario) == null)
            {
                throw new DbValidationException("O Id do usuário do anúncio é inválido.");
            }
        }

        public IEnumerable<dynamic> BuscarAnuncios(FiltroAnuncioRequest aFiltro)
        {
            StringBuilder stringBuilder = new StringBuilder(Resource.BuscarAnuncios);

            #region .: Filtros :.

            if (aFiltro != null)
            {
                if (Validador.FiltroIsValid(aFiltro.IdEstado))
                {
                    stringBuilder.Append($" AND A.EST_CODIGO = {aFiltro.IdEstado}");
                }

                if (Validador.FiltroIsValid(aFiltro.IdCidade))
                {
                    stringBuilder.Append($" AND A.CID_CODIGO = {aFiltro.IdCidade}");
                }

                if (Validador.FiltroIsValid(aFiltro.IdAnimal))
                {
                    stringBuilder.Append($" AND P.ANI_CODIGO = {aFiltro.IdAnimal}");
                }

                if (Validador.FiltroIsValid(aFiltro.IdSexo))
                {
                    stringBuilder.Append($" AND P.PTS_CODIGO = {aFiltro.IdSexo}");
                }

                if (Validador.FiltroIsValid(aFiltro.IdPorte))
                {
                    stringBuilder.Append($" AND P.PPR_CODIGO = {aFiltro.IdPorte}");
                }

                if (Validador.FiltroIsValid(aFiltro.IdRacaEspecie))
                {
                    stringBuilder.Append($" AND P.RAC_CODIGO = {aFiltro.IdRacaEspecie}");
                }

                if (Validador.FiltroIsValid(aFiltro.IdPelo))
                {
                    stringBuilder.Append($" AND P.PPL_CODIGO = {aFiltro.IdPelo}");
                }

                if (Validador.FiltroIsValid(aFiltro.IdIdade))
                {
                    stringBuilder.Append($" AND P.PID_CODIGO = {aFiltro.IdIdade}");
                }

                if (Validador.FiltroIsValid(aFiltro.IdCor))
                {
                    stringBuilder.Append($" AND P.COR_PRIMARIA = {aFiltro.IdCor}");
                }

                if (Validador.FiltroIsValid(aFiltro.Nome))
                {
                    stringBuilder.Append($" AND P.PET_NOME LIKE %{aFiltro.Nome}%");
                }
            }
            else
            {
                aFiltro = new FiltroAnuncioRequest()
                {
                    Quantidade = 16,
                    Pagina = 1
                };
            }

            #endregion

            #region .: Paginação :.

            stringBuilder.Append($" ORDER BY A.ANU_DTHCADASTRO DESC ");
            stringBuilder.Append($" OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY "); 

            #endregion

            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query(stringBuilder.ToString(), new { @PageSize = aFiltro.Quantidade, @PageNumber = aFiltro.Pagina });
            }
        }

        public IEnumerable<dynamic> BuscarAnunciosDestaques()
        {
            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query(Resource.BuscarAnunciosDestaques);
            }
        }
    }
}
