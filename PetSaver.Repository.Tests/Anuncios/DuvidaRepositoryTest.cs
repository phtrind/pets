using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Anuncios;
using PetSaver.Repository.Anuncios;

namespace PetSaver.Repository.Tests.Anuncios
{
    [TestClass]
    public class DuvidaRepositoryTest : BaseRepositoryTest
    {
        [TestMethod]
        public void Inserir_ValidDuvida_DoesntThrowException()
        {
            var codigo = new DuvidaRepository().Inserir(new DuvidaEntity()
            {
                IdLoginCadastro = 1,
                IdAnuncio = 2,
                IdUsuario = 3,
                Pergunta = "Pergunta teste"
            });

            Assert.IsTrue(codigo > 0);
        }
    }
}
