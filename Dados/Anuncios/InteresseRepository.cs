using Dapper;
using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PetSaver.Repository.Anuncios
{
    public class InteresseRepository : BaseRepository<InteresseEntity>
    {
        #region .: Validações :.

        protected override void ValidarAtributos(InteresseEntity aObjeto)
        {
            if (aObjeto.IdUsuario == default || new UsuarioRepository().Listar(aObjeto.IdUsuario) == null)
            {
                throw new DbValidationException("O Id do usuário do interesse é inválido.");
            }

            var anuncio = new AnuncioRepository().Listar(aObjeto.IdAnuncio);

            if (aObjeto.IdAnuncio == default || anuncio == null)
            {
                throw new DbValidationException("O Id do anúncio do interesse é inválido.");
            }

            if (anuncio.IdUsuario == aObjeto.IdUsuario)
            {
                throw new BusinessException("Não é possível cadastrar um interesse que seja do mesmo usuário do anúncio.");
            }

            if (Utilities.Conversor.IntParaEnum<StatusAnuncio>(anuncio.IdStatus) != StatusAnuncio.Ativo)
            {
                throw new BusinessException("Não é possível cadastrar um interesse em um anúncio que não está ativo.");
            }

            if (!Enum.IsDefined(typeof(StatusInteresse), aObjeto.IdStatus))
            {
                throw new DbValidationException("O Id do status do interesse é inválido.");
            }

            if (aObjeto.Id == default && BuscarPorUsuarioAnuncio(aObjeto.IdUsuario, aObjeto.IdAnuncio) != null)
            {
                throw new BusinessException("O usuário já tem um interesse cadastrado nesse anúncio.");
            }
        } 

        #endregion

        #region .: Consultas :.

        public InteresseEntity BuscarPorUsuarioAnuncio(int aIdUsuario, int aIdAnuncio)
        {
            if (aIdUsuario == default || aIdAnuncio == default)
            {
                return null;
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<InteresseEntity>(Resource.BuscarInteressePorUsuarioAnuncio, new { @IdUsuario = aIdUsuario, @IdAnuncio = aIdAnuncio });
            }
        }

        public IEnumerable<dynamic> BuscarRelatorioInteresses(RelatorioInteressesRequest aRequest)
        {
            if (aRequest.IdUsuario == default)
            {
                return new List<dynamic>();
            }

            var stringBuilder = new StringBuilder(Resource.RelatorioInteresses);

            if (Utilities.Validador.FiltroIsValid(aRequest.Nome))
            {
                stringBuilder.Append($" AND PET.PET_NOME LIKE '%{aRequest.Nome}%'");
            }

            if (Utilities.Validador.FiltroIsValid(aRequest.IdAnimal))
            {
                stringBuilder.Append($" AND ANI.ANI_CODIGO = {aRequest.IdAnimal}");
            }

            if (Utilities.Validador.FiltroIsValid(aRequest.IdTipoAnuncio))
            {
                stringBuilder.Append($" AND ANT.ANT_CODIGO = {aRequest.IdTipoAnuncio}");
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query(stringBuilder.ToString(), new { @IdUsuario = aRequest.IdUsuario });
            }
        }

        public IEnumerable<dynamic> BuscarInteressadosPorAnuncio(int aIdAnuncio)
        {
            if (aIdAnuncio == default)
            {
                return new List<dynamic>();
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query(Resource.BuscarInteressados, new { @IdAnuncio = aIdAnuncio });
            }
        }

        #endregion

        #region .: Cadastros :.

        public void FinalizarDemaisInteresses(int aIdAnuncio, int aIdUsuario, int aIdLogin)
        {
            if (aIdAnuncio == default)
            {
                throw new BusinessException("O Id do anúnico é inválido.");
            }

            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            if (aIdLogin == default)
            {
                throw new BusinessException("O Id do login é inválido.");
            }

            using (var db = new SqlConnection(StringConnection))
            {
                db.Execute(Resource.FinalizarDemaisInteresses, new { @IdAnuncio = aIdAnuncio, @IdUsuario = aIdUsuario, @IdLogin = aIdLogin });
            }
        }

        #endregion
    }
}
