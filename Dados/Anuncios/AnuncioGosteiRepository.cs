using System;
using System.Data.SqlClient;
using Dapper;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Entity.Enums.Tipos;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;

namespace PetSaver.Repository.Anuncios
{
    public class AnuncioGosteiRepository : BaseRepository<AnuncioGosteiEntity>
    {
        #region .: Validações :.

        protected override void ValidarAtributos(AnuncioGosteiEntity aObjeto)
        {
            var anuncio = new AnuncioRepository().Listar(aObjeto.IdAnuncio);

            if (aObjeto.IdAnuncio == default || anuncio == null)
            {
                throw new DbValidationException("O Id do anúncio é inválido.");
            }

            if (Utilities.Conversor.IntParaEnum<StatusAnuncio>(anuncio.IdStatus) != StatusAnuncio.Ativo)
            {
                throw new BusinessException("Não é possível gostar de um anúncio que não está ativo.");
            }

            if (Utilities.Conversor.IntParaEnum<TiposAnuncio>(anuncio.IdTipo) != TiposAnuncio.Doacao)
            {
                throw new BusinessException("Só é possível gostar de anúncios do tipo Doação.");
            }

            if (aObjeto.IdUsuario == default || new UsuarioRepository().Listar(aObjeto.IdUsuario) == null)
            {
                throw new DbValidationException("O Id do usuário é inválido.");
            }

            if (anuncio.IdUsuario == aObjeto.IdUsuario)
            {
                throw new BusinessException("Não é possível gostar de um anúncio próprio.");
            }
        }

        #endregion

        #region .: Cadastro :.

        public void RemoverGostei(int aIdAnuncio, int aIdUsuario)
        {
            using (var db = new SqlConnection(StringConnection))
            {
                db.Execute(Resource.RemoverGostei, new { @IdAnuncio = aIdAnuncio, @IdUsuario = aIdUsuario });
            }
        } 

        #endregion

        #region .: Buscas :.

        public AnuncioGosteiEntity BuscarPorAnuncioUsuario(int aIdAnuncio, int aIdUsuario)
        {
            if (aIdAnuncio == default)
            {
                throw new BusinessException("O Id do anuncio é inválido.");
            }

            if (aIdUsuario == default)
            {
                throw new BusinessException("O Id do usuário é inválido.");
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.QueryFirstOrDefault<AnuncioGosteiEntity>(Resource.BuscarAnuncioGosteiPorAnuncioUsuario, new { @IdAnuncio = aIdAnuncio, @IdUsuario = aIdUsuario });
            }
        } 

        #endregion
    }
}
