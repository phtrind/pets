﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Usuario;
using PetSaver.Entity.Enums;
using PetSaver.Entity.Usuarios;
using PetSaver.Exceptions;
using System;
using System.Linq;

namespace PetSaver.Business.Tests.Usuarios
{
    [TestClass]
    public class FuncionarioBusinessTest : BaseBusinessTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidRegister_Insert()
        {
            var idLogin = new LoginBusiness().Inserir(new LoginEntity()
            {
                Email = "asdasdasd@teste.com.br",
                Senha = "123456",
                IdTipo = Utilities.Conversor.EnumParaInt(TiposLogin.Funcionario),
                IdLoginCadastro = 1
            });

            var id = new FuncionarioBusiness().Inserir(new FuncionarioEntity()
            {
                Nome = "Pedro",
                Sobrenome = "Trindade",
                DataNascimento = DateTime.Now,
                Documento = "12994918633",
                Sexo = "M",
                DataAdmissao = DateTime.Now,
                IdLogin = idLogin,
                IdLoginCadastro = 1
            });

            Assert.IsTrue(id > 0);
        }

        #endregion

        #region .: Buscas :.

        [TestMethod]
        public void Listar_FuncionarioExistente_ReturnsUsuario()
        {
            var funcionario = new FuncionarioBusiness().Listar(1);

            Assert.IsNotNull(funcionario);
        }

        [TestMethod]
        public void ListarTodos_FuncionariosExistentes_ReturnsList()
        {
            var list = new FuncionarioBusiness().ListarTodos();

            Assert.IsTrue(list.Any());
        }

        [TestMethod]
        public void BuscarPorLogin_Existente_ReturnsEntity()
        {
            var entity = new FuncionarioBusiness().BuscarPorLogin(38);

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void BuscarPorLogin_Inexistente_ReturnsNull()
        {
            var entity = new FuncionarioBusiness().BuscarPorLogin(5000);

            Assert.IsNull(entity);
        }

        [TestMethod]
        public void BuscarPorLogin_Invalido_ReturnsNull()
        {
            var entity = new FuncionarioBusiness().BuscarPorLogin(0);

            Assert.IsNull(entity);
        }

        [TestMethod]
        public void IsFuncionario_Funcionario_ReturnsTrue()
        {
            Assert.IsTrue(new FuncionarioBusiness().IsFuncionario(38));
        }

        [TestMethod]
        public void IsFuncionario_Invalido_ReturnsFalse()
        {
            Assert.IsFalse(new FuncionarioBusiness().IsFuncionario(0));
        }

        [TestMethod]
        public void IsFuncionario_Nao_ReturnsFalse()
        {
            Assert.IsFalse(new FuncionarioBusiness().IsFuncionario(10));
        }

        #endregion
    }
}
