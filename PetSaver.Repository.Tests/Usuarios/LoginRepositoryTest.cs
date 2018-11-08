using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Enums;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;

namespace PetSaver.Repository.Tests
{
    [TestClass]
    public class LoginRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidLogin_DoesntThrowException()
        {
            var login = new Entity.Usuarios.LoginEntity()
            {
                Email = "teste_usuario@hotmail.com",
                Senha = "12345678",
                IdLoginCadastro = 1,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposLogin.Usuario)
            };

            var codigo = new LoginRepository().Inserir(login);

            Assert.IsTrue(codigo > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O e-mail do Login já está cadastrado no sistema.")]
        public void Inserir_ExistingEmail_ThrowsBusinessException()
        {
            var login = new Entity.Usuarios.LoginEntity()
            {
                Email = "phtrind@hotmail.com",
                Senha = "123",
                IdLoginCadastro = 1,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposLogin.Funcionario)
            };

            new LoginRepository().Inserir(login);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "E-mail do Login inválido.")]
        public void Inserir_InvalidEmail_ThrowsBusinessException()
        {
            var login = new Entity.Usuarios.LoginEntity()
            {
                Email = "teste",
                Senha = "123",
                IdLoginCadastro = 1,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposLogin.Funcionario)
            };

            new LoginRepository().Inserir(login);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Senha do Login inválida.")]
        public void Inserir_InvalidPassword_ThrowsBusinessException()
        {
            var login = new Entity.Usuarios.LoginEntity()
            {
                Email = "teste@teste.com",
                Senha = "123",
                IdLoginCadastro = 1,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposLogin.Funcionario)
            };

            new LoginRepository().Inserir(login);
        }

        #endregion

        #region .: Buscas :.

        [TestMethod]
        public void Listar_ExistingId_ReturnsEntity()
        {
            var entity = new LoginRepository().Listar(1);

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void Listar_NonexistentId_ReturnsEntity()
        {
            var entity = new LoginRepository().Listar(1000);

            Assert.IsNull(entity);
        }

        [TestMethod]
        public void BuscarPorEmail_ExistingEmail_ReturnsEntity()
        {
            var entity = new LoginRepository().BuscarPorEmail("phtrind@hotmail.com");

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void BuscarPorEmail_NonexistentEmail_ReturnsEntity()
        {
            var entity = new LoginRepository().BuscarPorEmail("testetesteteste");

            Assert.IsNull(entity);
        }

        [TestMethod]
        public void BuscarPorEmailSenha_ExistingEmail_ReturnsEntity()
        {
            var entity = new LoginRepository().BuscarPorEmailSenha("phtrind@hotmail.com", "123");

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void BuscarPorEmailSenha_NonexistentEmail_ReturnsEntity()
        {
            var entity = new LoginRepository().BuscarPorEmailSenha("phtrind@hotmail.com", "12334");

            Assert.IsNull(entity);
        }

        #endregion
    }
}
