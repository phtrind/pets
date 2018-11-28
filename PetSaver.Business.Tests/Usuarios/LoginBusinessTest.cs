using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Usuarios;
using PetSaver.Exceptions;

namespace PetSaver.Business.Tests.Usuarios
{
    [TestClass]
    public class LoginBusinessTest : BaseBusinessTest
    {
        [TestMethod]
        public void EfetuarLogin_ValidLogin_DoesntThrowException()
        {
            new LoginBusiness().EfetuarLogin("phtrind@hotmail.com", "123");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O login não foi encontrado em nossa base de dados.")]
        public void EfetuarLogin_InvalidLogin_ThrowsBusinessException()
        {
            new LoginBusiness().EfetuarLogin("phtrind@hotmail.com", "123456789123");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O campo de nome de usuário não pode estar vazio.")]
        public void EfetuarLogin_WihtoutUsername_ThrowsBusinessException()
        {
            new LoginBusiness().EfetuarLogin("", "123456789123");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O campo de senha não pode estar vazio.")]
        public void EfetuarLogin_WihtoutPassword_ThrowsBusinessException()
        {
            new LoginBusiness().EfetuarLogin("phtrind@hotmail.com", "");
        }

        [TestMethod]
        public void VerificarEmailExistente_EmailExistente_ReturnsTrue()
        {
            Assert.IsTrue(new LoginBusiness().VerificarEmailExistente("usuario@hotmail.com"));
        }

        [TestMethod]
        public void VerificarEmailExistente_EmailInexistente_ReturnsFalse()
        {
            Assert.IsFalse(new LoginBusiness().VerificarEmailExistente("asdasdasda"));
        }
    }
}
