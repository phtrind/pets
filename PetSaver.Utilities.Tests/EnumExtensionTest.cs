using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Enums.Pets;
using PetSaver.Utilities.Extensions;

namespace PetSaver.Utilities.Tests
{
    [TestClass]
    public class EnumExtensionTest
    {
        [TestMethod]
        public void Traduzir_PetSexos_ReturnsString()
        {
            var str = Sexos.Macho.Traduzir();

            Assert.IsTrue(str == "Macho");
        }

        [TestMethod]
        public void Traduzir_PetIdades_ReturnsString()
        {
            var str = Idades.Idoso.Traduzir();

            Assert.IsTrue(str == "Idoso");
        }
    }
}
