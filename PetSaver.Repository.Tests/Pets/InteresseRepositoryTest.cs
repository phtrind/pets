using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Repository.Anuncios;

namespace PetSaver.Repository.Tests.Pets
{
    [TestClass]
    public class InteresseRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_InteresseValido_DoesntThrowException()
        {
            var interesse = new InteresseEntity()
            {
                IdLoginCadastro = 1,
                IdUsuario = 3,
                IdAnuncio = 2,
                IdStatus = Utilities.Conversor.EnumParaInt(StatusInteresse.EmAndamento)
            };

            var idInteresse = new InteresseRepository().Inserir(interesse);

            Assert.IsTrue(idInteresse > 0);
        }

        #endregion

        #region .: Busca :.

        [TestMethod]
        public void Listar_ExistingInteresse_ReturnsEntity()
        {
            var interesse = new InteresseRepository().Listar(1);

            Assert.IsNotNull(interesse);
        }

        [TestMethod]
        public void Listar_UnexistentInteresse_ReturnsNull()
        {
            var interesse = new InteresseRepository().Listar(1000);

            Assert.IsNull(interesse);
        }

        [TestMethod]
        public void BuscarPorUsuarioAnuncio_Existing_ReturnsEntity()
        {
            var interesse = new InteresseRepository().BuscarPorUsuarioAnuncio(3, 2);

            Assert.IsNotNull(interesse);
        }

        [TestMethod]
        public void BuscarPorUsuarioAnuncio_Unexistent_ReturnsNull()
        {
            var interesse = new InteresseRepository().BuscarPorUsuarioAnuncio(344, 200);

            Assert.IsNull(interesse);
        }

        #endregion
    }
}
