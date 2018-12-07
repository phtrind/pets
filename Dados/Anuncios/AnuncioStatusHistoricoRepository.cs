using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;
using System;

namespace PetSaver.Repository.Anuncios
{
    public class AnuncioStatusHistoricoRepository : BaseRepository<AnuncioStatusHistoricoEntity>
    {
        protected override void ValidarAtributos(AnuncioStatusHistoricoEntity aObjeto)
        {
            if (aObjeto.IdAnuncio == default || new AnuncioRepository().Listar(aObjeto.IdAnuncio) == null)
            {
                throw new DbValidationException("O Id do Interesse é inválido.");
            }

            if (!Enum.IsDefined(typeof(StatusAnuncio), aObjeto.IdStatus))
            {
                throw new DbValidationException("O Id do status do anúncio é inválido.");
            }
        }
    }
}
