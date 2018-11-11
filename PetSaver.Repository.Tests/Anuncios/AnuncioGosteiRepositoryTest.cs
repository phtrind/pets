using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Anuncios;
using PetSaver.Repository.Anuncios;

namespace PetSaver.Repository.Tests.Anuncios
{
    [TestClass]
    public class AnuncioGosteiRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_AnuncioGosteiValido_DoesntThrowException()
        {
            var anuncio = new AnuncioGosteiEntity()
            {
                IdLoginCadastro = 1,
                IdAnuncio = 2,
                IdUsuario = 4
            };

            var idAnuncioGostei = new AnuncioGosteiRepository().Inserir(anuncio);

            Assert.IsTrue(idAnuncioGostei > 0);
        }

        #endregion

    }
}
