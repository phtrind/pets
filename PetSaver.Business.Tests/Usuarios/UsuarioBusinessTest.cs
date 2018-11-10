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
        [TestMethod]
        public void CadastrarBasico_UsuarioValido_DoesntThrowExeption()
        {
            var request = new CadastroBasicoRequest()
            {
                Nome = "Bruno",
                Sobrenome = "Lima",
                DataNascimento = Convert.ToDateTime("01/05/1995"),
                Email = "brunolima@petsaver.com",
                Senha = "brunao123"
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
    }
}
