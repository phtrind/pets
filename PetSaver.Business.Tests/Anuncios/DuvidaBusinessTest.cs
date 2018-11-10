using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
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

        [TestMethod]
        public void Cadastrar_DuvidaValida_DoesntThrowException()
        {
            var codigo = new DuvidaBusiness().Cadastrar(new CadastrarDuvidaRequest()
            {
                IdAnuncio = 2,
                IdUsuario = 3,
                Pergunta = "Pergunta teste cadastrar business"
            });

            Assert.IsTrue(codigo > 0);
        }
    }
}
