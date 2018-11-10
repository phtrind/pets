using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using System.Linq;

namespace PetSaver.Business.Tests.Anuncios
{
    [TestClass]
    public class AnuncioBusinessTest : BaseBusinessTest
    {
        #region .: Buscas :.

        [TestMethod]
        public void ListarDestaquesMiniaturas_WithResults_ReturnsList()
        {
            var listaMiniaturasDestaque = new AnuncioBusiness().ListarDestaquesMiniaturas();

            Assert.IsTrue(listaMiniaturasDestaque.Any());
        }

        [TestMethod]
        public void ListarMiniaturas_WithoutFilter_ReturnsList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarMiniaturas(null);

            Assert.IsTrue(listaMiniaturas.Any());
        }

        [TestMethod]
        public void ListarMiniaturas_WithFilter_ReturnsEmptyList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarMiniaturas(new Contracts.Anuncios.FiltroAnuncioRequest()
            {
                Pagina = 2
            });

            Assert.IsFalse(listaMiniaturas.Any());
        }

        [TestMethod]
        public void AbrirAnuncio_ExistingAnuncio_ReturnsObject()
        {
            var obj = new AnuncioBusiness().AbrirAnuncio(2, 3);

            Assert.IsNotNull(obj);
        }

        #endregion
    }
}
