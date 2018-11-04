using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Localizacao;
using PetSaver.Repository.Localizacao;

namespace PetSaver.Repository.Tests.Localizacao
{
    [TestClass]
    public class EstadoRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidEstado_DoesntThrowException()
        {
            var usuario = new EstadoEntity()
            {
                Sigla = "MG",
                Nome = "Minas Gerais",
                IdLoginCadastro = 1,
            };

            var codigo = new EstadoRepository().Inserir(usuario);

            Assert.IsTrue(codigo > 0);
        }

        #endregion
    }
}
