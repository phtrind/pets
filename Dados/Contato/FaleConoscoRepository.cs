using PetSaver.Entity.Contato;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;

namespace PetSaver.Repository.Contato
{
    public class FaleConoscoRepository : BaseRepository<FaleConoscoEntity>
    {
        protected override void ValidarCadastro(FaleConoscoEntity aObjeto)
        {
            ValidarAtributos(aObjeto);

            if (aObjeto.Id != default)
            {
                throw new DbValidationException("Não é possível cadastrar um objeto que já tenha um Id definido");
            }

            if (aObjeto.DataCadastro == default)
            {
                throw new DbValidationException("Data de cadastro inválida.");
            }
        }

        protected override void ValidarAtributos(FaleConoscoEntity aObjeto)
        {
            if (aObjeto.IdUsuario.HasValue && aObjeto.IdUsuario.Value != default && new UsuarioRepository().Listar(aObjeto.IdUsuario.Value) == null)
            {
                throw new DbValidationException("O Id do usuário é inválido.");
            }

            //TODO: Implementar validação do Id do funcionário

            if (aObjeto.IdUsuario == default && string.IsNullOrEmpty(aObjeto.Email))
            {
                throw new BusinessException("É obrigatório informar o e-mail quando o usuário não é informado.");
            }
            else if (aObjeto.IdUsuario == default && !Utilities.Validador.EmailIsValid(aObjeto.Email))
            {
                throw new BusinessException("O e-mail informado é inválido.");
            }

            if (string.IsNullOrEmpty(aObjeto.Mensagem))
            {
                throw new BusinessException("É obrigatório informar a mensagem.");
            }
        }
    }
}
