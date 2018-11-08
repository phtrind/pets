using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Anuncios;
using PetSaver.Entity.Enums.Status;
using PetSaver.Entity.Enums.Tipos;
using PetSaver.Repository.Anuncios;

namespace PetSaver.Repository.Tests.Pets
{
    [TestClass]
    public class AnuncioRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_AnuncioValido_DoesntThrowException()
        {
            var anuncio = new AnuncioEntity()
            {
                IdLoginCadastro = 1,
                IdStatus = Utilities.Conversor.EnumParaInt(StatusAnuncio.EmAnalise),
                IdTipo = Utilities.Conversor.EnumParaInt(TiposAnuncio.Doacao),
                IdPet = 1,
                IdLocalizacao = 1,
                IdEstado = 91,
                IdCidade = 6972,
                IdUsuario = 2
            };

            var idAnuncio = new AnuncioRepository().Inserir(anuncio);

            Assert.IsTrue(idAnuncio > 0);
        }

        #endregion

        #region .: Edição :.

        [TestMethod]
        public void Atualizar_AnuncioValido_DoesntThrowException()
        {
            var repository = new AnuncioRepository();

            var anuncio = repository.Listar(1);

            anuncio.IdLocalizacao = 3;
            anuncio.IdLoginAlteracao = 1;

            repository.Atualizar(anuncio);
        }

        #endregion

        #region .: Busca :.

        [TestMethod]
        public void Listar_ExistingAnuncio_ReturnsEntity()
        {
            var anuncio = new AnuncioRepository().Listar(1);

            Assert.IsNotNull(anuncio);
        }

        [TestMethod]
        public void Listar_UnexistentAnuncio_ReturnsNull()
        {
            var anuncio = new AnuncioRepository().Listar(100);

            Assert.IsNull(anuncio);
        }

        #endregion
    }
}
