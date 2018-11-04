using PetSaver.Entity.Localizacao;
using PetSaver.Exceptions;

namespace PetSaver.Repository.Localizacao
{
    public class EstadoRepository : BaseRepository<EstadoEntity>
    {
        protected override void ValidarAtributos(EstadoEntity aObjeto)
        {
            if (aObjeto.Sigla.Length != 2)
            {
                throw new BusinessException("A sigla do estado é inválida.");
            }

            if (string.IsNullOrEmpty(aObjeto.Nome))
            {
                throw new BusinessException("A nome do estado é inválido.");
            }
        }
    }
}
