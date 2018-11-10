using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Exceptions;

namespace PetSaver.Business.Tests.Anuncios
{
    [TestClass]
    public class InteresseBusinessTest : BaseBusinessTest
    {
        [TestMethod]
        public void Cadastrar_InteresseValido_DoesntThrowException()
        {
            var codigo = new InteresseBusiness().Cadastrar(new CadastrarInteresseRequest()
            {
                IdUsuario = 4,
                IdAnuncio = 2
            });

            Assert.IsTrue(codigo > 0);
        }

        [ExpectedException(typeof(BusinessException), "O usuário já tem um interesse cadastrado nesse anúncio.")]
        [TestMethod]
        public void Cadastrar_InteresseJaExistente_ThrowBusinessException()
        {
            new InteresseBusiness().Cadastrar(new CadastrarInteresseRequest()
            {
                IdUsuario = 4,
                IdAnuncio = 2
            });
        }
    }
}
