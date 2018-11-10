using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Anuncios;
using PetSaver.Repository.Anuncios;

namespace PetSaver.Repository.Tests.Anuncios
{
    [TestClass]
    public class AvaliacaoRepositoryTest : BaseRepositoryTest
    {
        [TestMethod]
        public void Inserir_AvaliacaoValida_DoesntThrowException()
        {
            var codigo = new AvaliacaoRepository().Inserir(new AvaliacaoEntity()
            {
                IdInteresse = 3,
                Nota = 4,
                IdAvaliado = 2,
                IdAvaliador = 4,
                IdLoginCadastro = 1
            });

            Assert.IsTrue(codigo > 0);
        }
    }
}
