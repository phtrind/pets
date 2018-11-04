using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PetSaver.Utilities.Tests
{
    [TestClass]
    public class StringUtilityTest
    {
        [TestMethod]
        public void RemoverNaoNumericos_StringWithNumbers_ReturnsStringWithoutNumbers()
        {
            string cpf = "129.949.186-33";

            cpf = StringUtility.RemoverNaoNumericos(cpf);

            Assert.IsTrue(cpf == "12994918633");
        }
    }
}
