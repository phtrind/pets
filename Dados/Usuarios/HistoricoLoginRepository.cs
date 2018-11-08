using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;

namespace PetSaver.Repository.Usuarios
{
    public class HistoricoLoginRepository : BaseRepository<HistoricoLoginEntity>
    {
        protected override void ValidarCadastro(HistoricoLoginEntity aObjeto)
        {
            if (aObjeto.Id != default)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha um Id definido");
            }

            if (aObjeto.DataCadastro == default)
            {
                throw new DbValidationException("Data de cadastro inválida.");
            }

            ValidarAtributos(aObjeto);
        }

        protected override void ValidarAtributos(HistoricoLoginEntity aObjeto)
        {
            if (aObjeto.IdLogin == default || new LoginRepository().Listar(aObjeto.IdLogin) == null)
            {
                throw new DbValidationException("O Id do login informado é inválido.");
            }
        }
    }
}
