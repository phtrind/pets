using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;

namespace PetSaver.Business.Usuarios
{
    public class LoginBusiness : BaseBusiness<LoginEntity, LoginRepository>
    {
        /// <summary>
        /// Método para autenticar as credenciais informadas
        /// </summary>
        /// <param name="aUsername">Nome de usuário</param>
        /// <param name="aPassword">Senha</param>
        /// <returns></returns>
        public void ValidarLogin(string aUsername, string aPassword)
        {
            if (string.IsNullOrEmpty(aUsername))
            {
                throw new BusinessException("O campo de nome de usuário não pode estar vazio.");
            }

            if (string.IsNullOrEmpty(aPassword))
            {
                throw new BusinessException("O campo de senha não pode estar vazio.");
            }

            if (new LoginRepository().BuscarPorEmailSenha(aUsername, aPassword) == null)
            {
                throw new BusinessException("O login não foi encontrado em nossa base de dados.");
            }
        }
    }
}
