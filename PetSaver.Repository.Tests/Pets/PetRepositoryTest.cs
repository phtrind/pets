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
                Nome = "Hulk",
                Peso = 58.6M,
                Vacinado = true,
                Vermifugado = false,
                Castrado = null,
                Descricao = "Cachorro teste, pastor alemão",
                IdAnimal = 1,
                IdRaca = 9,
                IdSexo = Utilities.Conversor.EnumParaInt(Sexos.Macho),
                IdIdade = Utilities.Conversor.EnumParaInt(Idades.Jovem),
                IdPorte = Utilities.Conversor.EnumParaInt(Portes.Grande),
                IdPelo = Utilities.Conversor.EnumParaInt(Pelos.Medio),
                IdCorPrimaria = 3,
                IdCorSecundaria = 9,
                IdLoginCadastro = 1
            };

            new PetRepository().Inserir(pet);
        } 

        #endregion
    }
}
