using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;

namespace PetSaver.Repository.Tests.Usuarios
{
    [TestClass]
    public class TipoLoginRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidTipoLogin_DoesntThrowException()
        {
            var tipoLogin = new TipoLoginEntity()
            {
                Descricao = "Usuário",
                IdLoginCadastro = 1,
            };

            var codigo = new TipoLoginRepository().Inserir(tipoLogin);

            Assert.IsTrue(codigo > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbValidationException), "O Id do usuário responsável pelo cadastro é inválido.")]
        public void Inserir_InvalidTipoLogin_ThrowException()
        {
            var tipoLogin = new TipoLoginEntity()
            {
                Descricao = "Usuário"
            };

            new TipoLoginRepository().Inserir(tipoLogin);
        }

        #endregion

        #region .: Atuaização :.

        [TestMethod]
        public void Atualizar_ValidTipoLogin_DoesntThrowException()
        {
            var dados = new TipoLoginRepository();

            var entity = dados.Listar(1);

            entity.Descricao = "Funcionário";
            entity.IdLoginAlteracao = 1;

            dados.Atualizar(entity);

            Assert.IsTrue(true);
        }

        #endregion

        #region .: Buscas :.

        [TestMethod]
        public void Listar_ExistingId_ReturnsEntity()
        {
            var entity = new TipoLoginRepository().Listar(1);

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void Listar_NonexistentId_ReturnsEntity()
        {
            var entity = new TipoLoginRepository().Listar(1000);

            Assert.IsNull(entity);
        } 

        #endregion
    }
}
