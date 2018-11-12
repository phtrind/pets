using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Enums.Pets;
using PetSaver.Entity.Pets;
using PetSaver.Repository.Pets;

namespace PetSaver.Repository.Tests.Pets
{
    [TestClass]
    public class PetRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidPet_DoesntThrowException()
        {
            var pet = new PetEntity()
            {
                Nome = "Nina",
                Peso = 15M,
                Vacinado = true,
                Vermifugado = false,
                Castrado = null,
                Descricao = "Cadela muito dócil e sensual.",
                IdAnimal = 1,
                IdRacaEspecie = 9,
                IdSexo = Utilities.Conversor.EnumParaInt(Sexos.Femea),
                IdIdade = Utilities.Conversor.EnumParaInt(Idades.Adulto),
                IdPorte = Utilities.Conversor.EnumParaInt(Portes.Pequeno),
                IdPelo = Utilities.Conversor.EnumParaInt(Pelos.Longo),
                IdCorPrimaria = 3,
                IdCorSecundaria = 9,
                IdLoginCadastro = 1
            };

            new PetRepository().Inserir(pet);
        }

        #endregion

        #region .: Busca :.

        [TestMethod]
        public void Listar_ExistingId_ReturnsEntity()
        {
            Assert.IsNotNull(new PetRepository().Listar(1));
        }

        [TestMethod]
        public void Listar_UnexistentId_ReturnsNull()
        {
            Assert.IsNull(new PetRepository().Listar(10000));
        }

        #endregion
    }
}
