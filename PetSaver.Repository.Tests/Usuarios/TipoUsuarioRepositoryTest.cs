using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;
using System;

namespace PetSaver.Repository.Tests.Usuarios
{
    [TestClass]
    public class TipoUsuarioRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidTipoLogin_DoesntThrowException()
        {
            var tipoLogin = new TipoUsuarioEntity()
            {
                Descricao = "Pessoa Jurídica",
                IdLoginCadastro = 1,
            };

            var codigo = new TipoUsuarioRepository().Inserir(tipoLogin);

            Assert.IsTrue(codigo > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbValidationException), "O Id do usuário responsável pelo cadastro é inválido.")]
        public void Inserir_InvalidTipoLogin_ThrowException()
        {
            var tipoLogin = new TipoLoginEntity()
            {
                Descricao = "Pessoa Jurídica",
                IdLoginCadastro = 100,
            };

            new TipoLoginRepository().Inserir(tipoLogin);
        }

        #endregion

        #region .: Atualização :.

        [TestMethod]
        public void Atualizar_ValidTipoLogin_DoesntThrowException()
        {
            var dados = new TipoUsuarioRepository();

            var entity = dados.Listar(1);

            entity.Descricao = "Pessoa Física";
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
