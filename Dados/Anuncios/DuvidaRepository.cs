using Dapper;
using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetSaver.Repository.Anuncios
{
    public class DuvidaRepository : BaseRepository<DuvidaEntity>
    {
        public override int Inserir(DuvidaEntity aObjeto)
        {
            aObjeto.DataHoraResposta = null;

            return base.Inserir(aObjeto);
        }

        protected override void ValidarAtributos(DuvidaEntity aObjeto)
        {
            if (aObjeto.IdUsuario == default || new UsuarioRepository().Listar(aObjeto.IdUsuario) == null)
            {
                throw new DbValidationException("O Id do usuário é inválido.");
            }

            var anuncio = new AnuncioRepository().Listar(aObjeto.IdAnuncio);

            if (aObjeto.IdAnuncio == default || anuncio == null)
            {
                throw new DbValidationException("O Id do anúncio é inválido.");
            }

            if (anuncio.IdUsuario == aObjeto.IdUsuario)
            {
                throw new BusinessException("Não é possível gravar uma dúvida para um anúncio próprio.");
            }

            if (string.IsNullOrEmpty(aObjeto.Pergunta))
            {
                throw new BusinessException("A pergunta deve ser preenchida.");
            }
        }

        public IEnumerable<DuvidaEntity> BuscarPorAnuncio(int aIdAnuncio)
        {
            if (aIdAnuncio == default)
            {
                return new List<DuvidaEntity>();
            }

            using (var db = new SqlConnection(StringConnection))
            {
                return db.Query<DuvidaEntity>(Resource.BuscarDuvidasPorAnuncio, new { @IdAnuncio = aIdAnuncio });
            }
        }
    }
}
