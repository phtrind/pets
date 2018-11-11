using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using PetSaver.Entity.Enums.Tipos;
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
        public void ListarMiniaturas_Doacao_ReturnsList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarMiniaturas(new Contracts.Anuncios.FiltroAnuncioRequest()
            {
                IdTipo = Utilities.Conversor.EnumParaInt(TiposAnuncio.Doacao)
            });

            Assert.IsTrue(listaMiniaturas.Any());
        }

        [TestMethod]
        public void ListarMiniaturas_PetPerdido_ReturnsEmptyList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarMiniaturas(new Contracts.Anuncios.FiltroAnuncioRequest()
            {
                IdTipo = Utilities.Conversor.EnumParaInt(TiposAnuncio.PetPerdido)
            });

            Assert.IsFalse(listaMiniaturas.Any());
        }

        [TestMethod]
        public void AbrirAnuncio_ExistingAnuncio_ReturnsObject()
        {
            var obj = new AnuncioBusiness().AbrirAnuncio(2, 3);

            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void ListarRelatorioDoacoes_ExistingAnuncios_ReturnsList()
        {
            var lista = new AnuncioBusiness().ListarRelatorioDoacoes(2, null);

            Assert.IsTrue(lista.Any());
        }

        [TestMethod]
        public void ListarRelatorioDoacoes_UnexistentAnuncios_ReturnsEmptyList()
        {
            var lista = new AnuncioBusiness().ListarRelatorioDoacoes(200, null);

            Assert.IsFalse(lista.Any());
        }

        #endregion
    }
}
