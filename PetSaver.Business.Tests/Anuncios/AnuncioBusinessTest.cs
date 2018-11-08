using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Business.Tests.Anuncios
{
    [TestClass]
    public class AnuncioBusinessTest : BaseBusinessTest
    {
        [TestMethod]
        public void ListarDestaquesMiniatura_WithResults_ReturnsList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarDestaquesMiniatura();

            Assert.IsTrue(listaMiniaturas.Any());
        }
    }
}
