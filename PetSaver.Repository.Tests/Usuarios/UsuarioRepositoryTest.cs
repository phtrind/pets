using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Enums;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using PetSaver.Repository.Usuarios;
using System;

namespace PetSaver.Repository.Tests.Usuarios
{
    [TestClass]
    public class UsuarioRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidUsuario_DoesntThrowException()
        {
            var usuario = new UsuarioEntity()
            {
                Nome = "Eduardo",
                Sobrenome = "Quelotti",
                DataNascimento = Convert.ToDateTime("19/07/1996"),
                Documento = "129.949.186-33",
                IdLogin = 4,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                IdLoginCadastro = 1,
            };

            var codigo = new UsuarioRepository().Inserir(usuario);

            Assert.IsTrue(codigo > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Nome inválido.")]
        public void Inserir_InvalidNome_ThrowException()
        {
            var usuario = new UsuarioEntity()
            {
                Sobrenome = "Trindade",
                DataNascimento = Convert.ToDateTime("19/07/1996"),
                Documento = "129.949.186-33",
                IdLogin = 4,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                IdLoginCadastro = 1,
            };

            new UsuarioRepository().Inserir(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Sobrenome inválido.")]
        public void Inserir_InvalidSobrenome_ThrowException()
        {
            var usuario = new UsuarioEntity()
            {
                Nome = "Pedro",
                DataNascimento = Convert.ToDateTime("19/07/1996"),
                Documento = "129.949.186-33",
                IdLogin = 4,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                IdLoginCadastro = 1,
            };

            new UsuarioRepository().Inserir(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Data de nascimento inválida.")]
        public void Inserir_InvalidDthNascimento_ThrowException()
        {
            var usuario = new UsuarioEntity()
            {
                Nome = "Pedro",
                Sobrenome = "Trindade",
                Documento = "129.949.186-33",
                IdLogin = 4,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                IdLoginCadastro = 1,
            };

            new UsuarioRepository().Inserir(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O documento do Usuário é inválido.")]
        public void Inserir_InvalidDocumento_ThrowException()
        {
            var usuario = new UsuarioEntity()
            {
                Nome = "Pedro",
                Sobrenome = "Trindade",
                DataNascimento = Convert.ToDateTime("19/07/1996"),
                Documento = "31561321651231211",
                IdLogin = 4,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                IdLoginCadastro = 1,
            };

            new UsuarioRepository().Inserir(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Já existe um usuário relacionado ao Id Login informado.")]
        public void Inserir_InvalidIdLogin_ThrowException()
        {
            var usuario = new UsuarioEntity()
            {
                Nome = "Pedro",
                Sobrenome = "Trindade",
                DataNascimento = Convert.ToDateTime("19/07/1996"),
                Documento = "129.949.186-33",
                IdLogin = 4,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                IdLoginCadastro = 1,
            };

            new UsuarioRepository().Inserir(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Já existe um usuário relacionado ao Documento informado.")]
        public void Inserir_ExistingDocumento_ThrowException()
        {
            var usuario = new UsuarioEntity()
            {
                Nome = "Pedro",
                Sobrenome = "Trindade",
                DataNascimento = Convert.ToDateTime("19/07/1996"),
                Documento = "129.949.186-33",
                IdLogin = 5,
                IdTipo = Utilities.Conversor.EnumParaInt(TiposUsuario.PessoaFisica),
                IdLoginCadastro = 1,
            };

            new UsuarioRepository().Inserir(usuario);
        }

        #endregion

        #region .: Atualização :.

        [TestMethod]
        public void Atualizar_ValidTipoLogin_DoesntThrowException()
        {
            var dados = new UsuarioRepository();

            var entity = dados.Listar(2);

            entity.Nome = "Pedro";
            entity.IdLoginAlteracao = 1;

            dados.Atualizar(entity);

            Assert.IsTrue(true);
        }

        #endregion

        #region .: Buscas :.

        [TestMethod]
        public void Listar_ExistingId_ReturnsEntity()
        {
            var entity = new UsuarioRepository().Listar(2);

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void Listar_NonexistentId_ReturnsEntity()
        {
            var entity = new UsuarioRepository().Listar(1000);

            Assert.IsNull(entity);
        }

        [TestMethod]
        public void BuscarPorLogin_ExistingLogin_ReturnsEntity()
        {
            var entity = new UsuarioRepository().BuscarPorLogin(4);

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void BuscarPorLogin_NonexistentLogin_ReturnsEntity()
        {
            var entity = new UsuarioRepository().BuscarPorLogin(1000);

            Assert.IsNull(entity);
        }

        [TestMethod]
        public void BuscarPorDocumento_ExistingDocumento_ReturnsEntity()
        {
            var entity = new UsuarioRepository().BuscarPorDocumento("129.949.186-33");

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void BuscarPorDocumento_NonexistentDocumento_ReturnsEntity()
        {
            var entity = new UsuarioRepository().BuscarPorDocumento("321");

            Assert.IsNull(entity);
        }

        #endregion
    }
}
