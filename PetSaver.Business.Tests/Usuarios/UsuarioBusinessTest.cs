using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Usuarios;
using PetSaver.Contracts.Usuario;
using PetSaver.Entity.Usuarios;
using System;
using System.Linq;

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
                Nome = "Lorrayne",
                Sobrenome = "Anacleto",
                DataNascimento = Convert.ToDateTime("20/04/1995"),
                Email = "lorrayne.20@hotmail.com",
                Senha = "lorrayneanacleto"
            };

            var idUsuario = new UsuarioBusiness().CadastrarBasico(request);

            Assert.IsTrue(idUsuario > 0);
        }
    }
}
