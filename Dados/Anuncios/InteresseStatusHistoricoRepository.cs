using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;
using System;

namespace PetSaver.Repository.Anuncios
{
    public class InteresseStatusHistoricoRepository : BaseRepository<InteresseStatusHistoricoEntity>
    {
        protected override void ValidarAtributos(InteresseStatusHistoricoEntity aObjeto)
        {
            if (aObjeto.IdInteresse == default || new InteresseRepository().Listar(aObjeto.IdInteresse) == null)
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
