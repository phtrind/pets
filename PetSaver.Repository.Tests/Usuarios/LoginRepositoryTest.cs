using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Repository.Usuarios;

namespace PetSaver.Repository.Tests
{
    [TestClass]
    public class LoginRepositoryTest : BaseRepositoryTest
    {
        [TestMethod]
        public void Insert_ValidLogin_DoesntThrowException()
        {
            var login = new Entity.Usuarios.LoginEntity()
            {
                Email = "phtrind@hotmail.com",
                Senha = "123",
                IdUsuarioCadastro = 1,
                IdTipo = 1
            };

            var dados = new LoginRepository();

            int codigo = dados.Inserir(login);

            Assert.IsTrue(codigo != 0);
        }
    }
}
