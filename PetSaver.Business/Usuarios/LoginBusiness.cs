using System;
using System.Threading.Tasks;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;
using PetSaver.Utilities;

namespace PetSaver.Business.Usuarios
{
    public class LoginBusiness : BaseBusiness<LoginEntity, LoginRepository>
    {
        /// <summary>
        /// Método para efetuar login no sistema
        /// </summary>
        /// <param name="aUsername">Nome de usuário</param>
        /// <param name="aPassword">Senha</param>
        /// <returns></returns>
        public void EfetuarLogin(string aUsername, string aPassword)
        {
            if (string.IsNullOrEmpty(aUsername))
            {
                throw new BusinessException("O campo de nome de usuário não pode estar vazio.");
            }

            if (string.IsNullOrEmpty(aPassword))
            {
                throw new BusinessException("O campo de senha não pode estar vazio.");
            }

            var login = new LoginRepository().BuscarPorEmailSenha(aUsername, aPassword);

            if (login == null)
            {
                throw new BusinessException("O login não foi encontrado em nossa base de dados.");
            }

            var historicoLogin = new HistoricoLoginEntity()
            {
                IdLogin = login.Id,
            };

            new HistoricoLoginBusiness().Inserir(historicoLogin);
        }

        /// <summary>
        /// Verificar se o e-mail já existe na base de dados
        /// </summary>
        /// <param name="aEmail">E-mail que será verificado</param>
        /// <returns></returns>
        public bool VerificarEmailExistente(string aEmail)
        {
            return new LoginRepository().BuscarPorEmail(aEmail) != null;
        }

        public async Task EsqueceuSenhaAsync(string aEmail)
        {
            var loginEntity = new LoginRepository().BuscarPorEmail(aEmail);

            if (loginEntity == null)
            {
                throw new BusinessException("O e-mail informado não existe.");
            }

            await new Email().EnviarEmail("Recuparar senha", $"Olá Saver, <br><br>Sua senha é: {loginEntity.Senha} <br><br>www.petsaver.com.br", aEmail, true);
        }
    }
}
