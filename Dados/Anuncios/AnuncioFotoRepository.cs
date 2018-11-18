using PetSaver.Entity.Anuncios;
using PetSaver.Exceptions;

namespace PetSaver.Repository.Anuncios
{
    public class AnuncioFotoRepository : BaseRepository<AnuncioFotoEntity>
    {
        protected override void ValidarAtributos(AnuncioFotoEntity aObjeto)
        {
            if (aObjeto.IdAnuncio == default || new AnuncioRepository().Listar(aObjeto.IdAnuncio) == null)
            {
                throw new DbValidationException("O Id do anúncio informado é inválido.");
            }

            if (string.IsNullOrEmpty(aObjeto.Caminho))
            {
                throw new BusinessException("O caminho da imagem informado é inválido.");
            }
        }
    }
}
