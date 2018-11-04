using PetSaver.Entity.Localizacao;
using PetSaver.Exceptions;

namespace PetSaver.Repository.Localizacao
{
    public class EnderecoRepository : BaseRepository<EnderecoEntity>
    {
        protected override void ValidarAtributos(EnderecoEntity aObjeto)
        {
            if (string.IsNullOrEmpty(aObjeto.Logradouro))
            {
                throw new BusinessException("O logradouro do endereço é inválido.");
            }

            if (string.IsNullOrEmpty(aObjeto.Bairro))
            {
                throw new BusinessException("O bairro do endereço é inválido.");
            }

            aObjeto.Cep = Utilities.StringUtility.RemoverNaoNumericos(aObjeto.Cep);

            if (string.IsNullOrEmpty(aObjeto.Cep))
            {
                throw new BusinessException("O cep do endereço é inválido.");
            }

            if (aObjeto.IdCidade == default || new CidadeRepository().Listar(aObjeto.IdCidade) == null)
            {
                throw new BusinessException("O Id da cidade do endereço é inválida.");
            }
        }
    }
}
