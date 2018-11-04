using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Usuarios;
using PetSaver.Repository;
using System.Linq;

namespace PetSaver.Business.Tests
{
    [TestClass]
    public class BaseBusinessTest
    {
        public BaseBusinessTest()
        {
            RegisterMappings.Register();
        }

        #region .: Buscas :.

        [TestMethod]
        public void ListarTodos_WithResuts_ReturnsList()
        {
            var lista = new UsuarioBusiness().ListarTodos();

            Assert.IsTrue(lista.Any());
        }

        [TestMethod]
        public void Listar_WithResuts_ReturnsEntity()
        {
            Assert.IsTrue(new UsuarioBusiness().Listar(2) != null);
        }

        #endregion
    }
}
