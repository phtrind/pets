using PetSaver.Entity.Localizacao;
using PetSaver.Exceptions;

namespace PetSaver.Repository.Localizacao
{
    public class CidadeRepository : BaseRepository<CidadeEntity>
    {
        protected override void ValidarAtributos(CidadeEntity aObjeto)
        {
            if (string.IsNullOrEmpty(aObjeto.Nome))
            {
                throw new BusinessException("O nome da cidade é inválida.");
            }

            if (aObjeto.IdEstado == default || new EstadoRepository().Listar(aObjeto.IdEstado) == null)
            {
                throw new BusinessException("O Id do estado da cidade é inválido.");
            }
        }
    }
}
