using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Localizacao;
using PetSaver.Repository.Localizacao;

namespace PetSaver.Repository.Tests.Localizacao
{
    [TestClass]
    public class LocalizacaoRepositoryTest : BaseRepositoryTest
    {
        [TestMethod]
        public void Inserir_LocalizacaoValida_DoesntThrowException()
        {
            var localizacao = new LocalizacaoEntity()
            {
                IdLoginCadastro = 1,
                Latitude = -19.905509,
                Longitude = -43.92418199999997
            };

            var idLocalizacao = new LocalizacaoRepository().Inserir(localizacao);

            Assert.IsTrue(idLocalizacao > 0);
        }
    }
}
