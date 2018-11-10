using Dapper;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetSaver.Repository.Anuncios
{
    public class AvaliacaoRepository : BaseRepository<AvaliacaoEntity>
    {
        #region .: Validação :.

        protected override void ValidarAtributos(AvaliacaoEntity aObjeto)
        {
            if (aObjeto.Nota < 0 || aObjeto.Nota > 5)
            {
                throw new BusinessException("A nota deve ser entre 0 e 5.");
            }

            var interesse = new InteresseRepository().Listar(aObjeto.IdInteresse);

            if (interesse == null)
            {
                throw new DbValidationException("O Id do interesse é inválido");
            }

            if (interesse.IdStatus == Utilities.Conversor.EnumParaInt(StatusInteresse.EmAndamento))
            {
                throw new BusinessException("Não é possível realizar uma avaliação referente à um interesse que ainda está em andamento.");
            }

            if (aObjeto.IdAvaliado == aObjeto.IdAvaliador)
            {
                throw new BusinessException("Não é possível inserir uma avaliação entre usuários iguais.");
            }

            var usuarioRepository = new UsuarioRepository();

            if (aObjeto.IdAvaliador == default || usuarioRepository.Listar(aObjeto.IdAvaliador) == null)
            {
                throw new DbValidationException("O Id do usuário avaliador é inválido.");
            }

            if (aObjeto.IdAvaliado == default || usuarioRepository.Listar(aObjeto.IdAvaliado) == null)
            {
                throw new DbValidationException("O Id do usuário avaliado é inválido.");
            }

            var anuncio = new AnuncioRepository().Listar(interesse.IdAnuncio);

            if (aObjeto.IdAvaliado != anuncio.IdUsuario && aObjeto.IdAvaliado != interesse.IdUsuario)
            {
                throw new BusinessException("O usuário avaliado não faz parte dessa relação de interesse.");
            }

            if (aObjeto.IdAvaliador != anuncio.IdUsuario && aObjeto.IdAvaliador != interesse.IdUsuario)
            {
                throw new BusinessException("O usuário avaliador não faz parte dessa relação de interesse.");
            }
        }

        #endregion

        #region .: Buscas :.

        public IEnumerable<AvaliacaoEntity> BuscarAvaliacaoPorUsuario(int aIdUsuario)
        {
            if (aIdUsuario == default)
            {
                return new List<AvaliacaoEntity>();
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query<AvaliacaoEntity>(Resource.BuscarAvaliacaoPorUsuario, new { @IdUsuario = aIdUsuario });
            }
        }

        #endregion
    }
}
