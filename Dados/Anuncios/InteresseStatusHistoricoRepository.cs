using PetSaver.Entity.Base;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;
using System;

namespace PetSaver.Repository.Anuncios
{
    public class InteresseStatusHistoricoRepository : BaseRepository<HistoricoStatusEntity>
    {
        protected override void ValidarAtributos(HistoricoStatusEntity aObjeto)
        {
            if (aObjeto.IdEntidade == default || new InteresseRepository().Listar(aObjeto.IdEntidade) == null)
            {
                throw new DbValidationException("O Id do Interesse é inválido.");
            }

            if (!Enum.IsDefined(typeof(StatusInteresse), aObjeto.IdStatus))
            {
                throw new DbValidationException("O Id do status do interesse é inválido.");
            }
        }
    }
}
