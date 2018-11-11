using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;

namespace PetSaver.Business.Tests.Anuncios
{
    [TestClass]
    public class AnuncioGosteiBusinessTest : BaseBusinessTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Cadastrar_ValidRegister_DoesntThrowException()
        {
            var codigo = new AnuncioGosteiBusiness().Cadastrar(new CadastrarGosteiRequest()
            {
                IdAnuncio = 2,
                IdUsuario = 4
            });

            Assert.IsTrue(codigo > 0);
        }

        [TestMethod]
        public void Remover_ValidRegister_DoesntThrowException()
        {
            new AnuncioGosteiBusiness().Remover(new CadastrarGosteiRequest()
            {
                IdAnuncio = 2,
                IdUsuario = 4
            });

            Assert.IsTrue(true);
        }

        #endregion

        #region .: Buscas :.

        [TestMethod]
        public void UsuarioGostouAnuncio_ExistingEntity_ReturnsTrue()
        {
            Assert.IsTrue(new AnuncioGosteiBusiness().UsuarioGostouAnuncio(2, 4));
        }

        [TestMethod]
        public void UsuarioGostouAnuncio_UnexitentEntity_ReturnsFalse()
        {
            Assert.IsFalse(new AnuncioGosteiBusiness().UsuarioGostouAnuncio(200, 400));
        } 

        #endregion
    }
}
