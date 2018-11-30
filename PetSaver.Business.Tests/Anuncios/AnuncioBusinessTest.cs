using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using PetSaver.Contracts.Anuncios;
using PetSaver.Entity.Enums.Pets;
using PetSaver.Entity.Enums.Tipos;
using System.Linq;

namespace PetSaver.Business.Tests.Anuncios
{
    [TestClass]
    public class AnuncioBusinessTest : BaseBusinessTest
    {
        #region .: Buscas :.

        [TestMethod]
        public void ListarDestaquesMiniaturas_WithResults_ReturnsList()
        {
            var listaMiniaturasDestaque = new AnuncioBusiness().ListarDestaquesMiniaturas();

            Assert.IsTrue(listaMiniaturasDestaque.Any());
        }

        [TestMethod]
        public void ListarMiniaturas_WithoutFilter_ReturnsList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarMiniaturas(null);

            Assert.IsTrue(listaMiniaturas.Any());
        }

        [TestMethod]
        public void ListarMiniaturas_WithFilter_ReturnsEmptyList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarMiniaturas(new Contracts.Anuncios.FiltroAnuncioRequest()
            {
                Pagina = 2
            });

            Assert.IsFalse(listaMiniaturas.Any());
        }

        [TestMethod]
        public void ListarMiniaturas_Doacao_ReturnsList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarMiniaturas(new Contracts.Anuncios.FiltroAnuncioRequest()
            {
                IdTipo = Utilities.Conversor.EnumParaInt(TiposAnuncio.Doacao)
            });

            Assert.IsTrue(listaMiniaturas.Any());
        }

        [TestMethod]
        public void ListarMiniaturas_PetPerdido_ReturnsEmptyList()
        {
            var listaMiniaturas = new AnuncioBusiness().ListarMiniaturas(new Contracts.Anuncios.FiltroAnuncioRequest()
            {
                IdTipo = Utilities.Conversor.EnumParaInt(TiposAnuncio.PetPerdido)
            });

            Assert.IsFalse(listaMiniaturas.Any());
        }

        [TestMethod]
        public void AbrirAnuncio_ExistingAnuncio_ReturnsObject()
        {
            var obj = new AnuncioBusiness().AbrirAnuncio(2, 3);

            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void ListarRelatorioDoacoes_ExistingAnuncios_ReturnsList()
        {
            var lista = new AnuncioBusiness().ListarRelatorioAnuncios(new RelatorioAnunciosRequest()
            {
                Filtro = null,
                IdUsuario = 2
            }, TiposAnuncio.Doacao);

            Assert.IsTrue(lista.Any());
        }

        #endregion

        #region .: Cadastros :.

        [TestMethod]
        public void CadastrarDoacao_ValidOneAnuncio_DoesntThrowException()
        {
            new AnuncioBusiness().Cadastrar(new CadastrarPetAnuncioRequest()
            {
                IdUsuario = 4,
                Anuncio = new CadastroAnuncioContract()
                {
                    IdEstado = 91,
                    IdCidade = 6972,
                    Pet = new CadastroPetContract()
                    {
                        IdAnimal = 2,
                        Nome = "Gato do Brunão",
                        IdSexo = Utilities.Conversor.EnumParaInt(Sexos.Macho),
                        IdRacaEspecie = 20,
                        IdIdade = Utilities.Conversor.EnumParaInt(Idades.Idoso),
                        IdPorte = Utilities.Conversor.EnumParaInt(Portes.Medio),
                        Peso = 26.3M,
                        IdPelo = Utilities.Conversor.EnumParaInt(Pelos.Longo),
                        IdCorPrimaria = 5,
                        IdCorSecundaria = 8,
                        Vacinado = null,
                        Vermifugado = true,
                        Castrado = false,
                        Descricao = "Gato sexy do Bruno Lima"
                    }
                }
            }, TiposAnuncio.Doacao);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CadastrarPetPerdido_ValidPetPerdido_DoesntThrowException()
        {
            new AnuncioBusiness().Cadastrar(new CadastrarPetAnuncioRequest()
            {
                IdUsuario = 4,
                Anuncio = new CadastroAnuncioContract()
                {
                    IdEstado = 91,
                    IdCidade = 6972,
                    Pet = new CadastroPetContract()
                    {
                        IdAnimal = 1,
                        Nome = "James Bond",
                        IdSexo = Utilities.Conversor.EnumParaInt(Sexos.Macho),
                        IdRacaEspecie = 7,
                        IdIdade = Utilities.Conversor.EnumParaInt(Idades.Jovem),
                        IdPorte = Utilities.Conversor.EnumParaInt(Portes.Medio),
                        Peso = 12M,
                        IdPelo = Utilities.Conversor.EnumParaInt(Pelos.Longo),
                        IdCorPrimaria = 4,
                        IdCorSecundaria = 1,
                        Vacinado = false,
                        Vermifugado = false,
                        Castrado = false,
                        Descricao = "Cachorro sexy do Bruno Lima o cabuloso."
                    }
                }
            }, TiposAnuncio.PetPerdido);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CadastrarPetPerdido_ValidPetEncontrado_DoesntThrowException()
        {
            new AnuncioBusiness().Cadastrar(new CadastrarPetAnuncioRequest()
            {
                IdUsuario = 4,
                Anuncio = new CadastroAnuncioContract()
                {
                    IdEstado = 82,
                    IdCidade = 5592,
                    Pet = new CadastroPetContract()
                    {
                        IdAnimal = 1,
                        IdSexo = Utilities.Conversor.EnumParaInt(Sexos.Macho),
                        IdRacaEspecie = 4,
                        IdIdade = Utilities.Conversor.EnumParaInt(Idades.Jovem),
                        IdPorte = Utilities.Conversor.EnumParaInt(Portes.Medio),
                        Peso = 12M,
                        IdPelo = Utilities.Conversor.EnumParaInt(Pelos.Longo),
                        IdCorPrimaria = 4,
                        IdCorSecundaria = 1,
                        Vacinado = false,
                        Vermifugado = false,
                        Castrado = false,
                        Descricao = "Encontrei na rua."
                    }
                }
            }, TiposAnuncio.PetEncontrado);

            Assert.IsTrue(true);
        }

        #endregion

    }
}
