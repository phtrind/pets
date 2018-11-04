using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Usuarios;
using PetSaver.Exceptions;

namespace PetSaver.Business.Tests.Usuarios
{
    [TestClass]
    public class LoginBusinessTest
    {
        [TestMethod]
        public void ValidarLogin_ValidLogin_DoesntThrowException()
        {
            new LoginBusiness().ValidarLogin("phtrind@hotmail.com", "123");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O login não foi encontrado em nossa base de dados.")]
        public void ValidarLogin_InvalidLogin_ThrowsBusinessException()
        {
            new LoginBusiness().ValidarLogin("phtrind@hotmail.com", "123456789123");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O campo de nome de usuário não pode estar vazio.")]
        public void ValidarLogin_WihtoutUsername_ThrowsBusinessException()
        {
            new LoginBusiness().ValidarLogin("", "123456789123");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O campo de senha não pode estar vazio.")]
        public void ValidarLogin_WihtoutPassword_ThrowsBusinessException()
        {
            new LoginBusiness().ValidarLogin("phtrind@hotmail.com", "");
        }
    }
}
