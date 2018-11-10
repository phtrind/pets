using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using System.Linq;

namespace PetSaver.Business.Tests.Anuncios
{
    [TestClass]
    public class DuvidaBusinessTest : BaseBusinessTest
    {
        [TestMethod]
        public void BuscarPorAnuncio_ExistingDuvida_ReturnList()
        {
            var lista = new DuvidaBusiness().BuscarPorAnuncio(2);

            Assert.IsTrue(lista.Any());
        }
    }
}
