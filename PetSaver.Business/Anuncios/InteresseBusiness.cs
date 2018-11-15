using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Exceptions;
using PetSaver.Repository.Anuncios;

namespace PetSaver.Business.Anuncios
{
    public class InteresseBusiness : BaseBusiness<InteresseEntity, InteresseRepository>
    {
        #region .: Cadastro :.

        public int Cadastrar(CadastrarInteresseRequest aRequest)
        {
            if (aRequest.IdUsuario == default)
            {
                throw new BusinessException("Não é possível cadastrar um interesse sem usuário.");
            }

            if (aRequest.IdAnuncio == default)
            {
                throw new BusinessException("Não é possível cadastrar um interesse sem anúncio.");
            }

            return Inserir(new InteresseEntity()
            {
                IdAnuncio = aRequest.IdAnuncio,
                IdUsuario = aRequest.IdUsuario,
                IdStatus = Utilities.Conversor.EnumParaInt(StatusInteresse.EmAndamento),
                IdLoginCadastro = new UsuarioBusiness().Listar(aRequest.IdUsuario)?.IdLogin ?? default
            });
        }

        #endregion

        #region .: Buscas :.

        public InteresseEntity BuscarPorUsuarioAnuncio(int aIdUsuario, int aIdAnuncio)
        {
            if (aIdUsuario == default || aIdAnuncio == default)
            {
                return null;
            }

            return new InteresseRepository().BuscarPorUsuarioAnuncio(aIdUsuario, aIdAnuncio);
        }

        #endregion
    }
}
