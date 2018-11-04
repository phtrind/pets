using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Enums;

namespace PetSaver.Utilities.Tests
{
    [TestClass]
    public class ConversorTest
    {
        [TestMethod]
        public void IntParaEnum_ExistingValue_ReturnsCorrectEnum()
        {
            var aEnum = Conversor.IntParaEnum<TiposUsuario>(1);

            Assert.IsTrue(aEnum == TiposUsuario.PessoaFisica);
        }

        [TestMethod]
        public void IntParaEnum_NonexistentValue_ReturnsCorrectEnum()
        {
            var aEnum = Conversor.IntParaEnum<TiposUsuario>(100);

            Assert.IsFalse(aEnum == TiposUsuario.PessoaFisica);
        }
    }
}
