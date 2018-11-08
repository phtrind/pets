using PetSaver.Entity.Localizacao;
using PetSaver.Exceptions;

namespace PetSaver.Repository.Localizacao
{
    public class LocalizacaoRepository : BaseRepository<LocalizacaoEntity>
    {
        protected override void ValidarAtributos(LocalizacaoEntity aObjeto)
        {
            if (aObjeto.Latitude == default)
            {
                throw new BusinessException("Latitude inválida");
            }

            if (aObjeto.Longitude == default)
            {
                throw new BusinessException("Longitude inválida");
            }
        }
    }
}
