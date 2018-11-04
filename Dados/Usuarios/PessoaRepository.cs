using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using PetSaver.Repository.Localizacao;

namespace PetSaver.Repository.Usuarios
{
    public class PessoaRepository<T> : BaseRepository<T> where T : PessoaEntity
    {
        #region .: Validação :.

        protected override void ValidarAtributos(T aObjeto)
        {
            if (string.IsNullOrEmpty(aObjeto.Nome))
            {
                throw new BusinessException("Nome inválido.");
            }

            if (string.IsNullOrEmpty(aObjeto.Sobrenome))
            {
                throw new BusinessException("Sobrenome inválido.");
            }

            if (aObjeto.DataNascimento == default)
            {
                throw new BusinessException("Data de nascimento inválida.");
            }

            //TAG: Essa validação deve ficar na classe de Funcionario, pois o Usuário pode ser cadastrado sem documento
            //if (string.IsNullOrEmpty(aObjeto.Documento))
            //{
            //    throw new BusinessException("Documento inválido.");
            //}

            if (aObjeto.IdEndereco.HasValue &&
                (aObjeto.IdEndereco.Value == default || new EnderecoRepository().Listar(aObjeto.IdEndereco.Value) == null))
            {
                throw new DbValidationException("O Id do endereço informado é inváido.");
            }

            if (!LoginExiste(aObjeto.IdLogin))
            {
                throw new DbValidationException("O Id do login informado não existe.");
            }

            aObjeto.Documento = Utilities.StringUtility.RemoverNaoNumericos(aObjeto.Documento);
        }

        #endregion
    }
}
