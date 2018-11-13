using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Usuario;
using PetSaver.Exceptions;
using System;

namespace PetSaver.Business.Tests.Usuarios
{
    [TestClass]
    public class UsuarioBusinessTest : BaseBusinessTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void CadastrarBasico_UsuarioValido_DoesntThrowExeption()
        {
            var request = new CadastroBasicoRequest()
            {
                Nome = "Carla",
                Sobrenome = "Almeida",
                DataNascimento = Convert.ToDateTime("14/07/1975"),
                Email = "carla.almeidarpa@yahoo.com.br",
                Senha = "12345678"
            };

            var idUsuario = new UsuarioBusiness().CadastrarBasico(request);

            Assert.IsTrue(idUsuario > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O e-mail do Login já está cadastrado no sistema.")]
        public void CadastrarBasico_EmailExistente_ThrowsBusinessExeption()
        {
            var request = new CadastroBasicoRequest()
            {
                Nome = "Lorrayne",
                Sobrenome = "Anacleto",
                DataNascimento = Convert.ToDateTime("20/04/1995"),
                Email = "lorrayne.20@hotmail.com",
                Senha = "lorrayneanacleto"
            };

            new UsuarioBusiness().CadastrarBasico(request);
        }

        #endregion

        #region .: Buscas :.

        [TestMethod]
        public void BuscarInformacoesSession_ExistingEmail_ReturnsEntity()
        {
            Assert.IsNotNull(new UsuarioBusiness().BuscarInformacoesSession("usuario@hotmail.com"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O usuário não foi encontrado.")]
        public void BuscarInformacoesSession_UnexistentEmail_ThrowsNotFoundException()
        {
            new UsuarioBusiness().BuscarInformacoesSession("teste");
        }

        #endregion
    }
}
