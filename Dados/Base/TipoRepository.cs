using PetSaver.Entity;
using PetSaver.Exceptions;

namespace PetSaver.Repository
{
    public class TipoRepository<T> : BaseRepository<T> where T : TipoEntity
    {
        protected override void ValidarAtributos(T aObjeto)
        {
            if (string.IsNullOrEmpty(aObjeto.Descricao))
            {
                throw new BusinessException("Descrição do tipo inválida.");
            }
        }
    }
}
