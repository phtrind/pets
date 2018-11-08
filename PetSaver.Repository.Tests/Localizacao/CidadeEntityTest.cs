using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Localizacao;
using PetSaver.Repository.Localizacao;

namespace PetSaver.Repository.Tests.Localizacao
{
    [TestClass]
    public class CidadeEntityTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidCidade_DoesntThrowException()
        {
            var usuario = new CidadeEntity()
            {
                Nome = "Belo Horizonte",
                IdEstado = 1,
                IdLoginCadastro = 1,
            };

            var codigo = new CidadeRepository().Inserir(usuario);

            Assert.IsTrue(codigo > 0);
        }

        #endregion
    }
}
