using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;

namespace PetSaver.Business.Tests.Anuncios
{
    [TestClass]
    public class AnuncioFotoBusinessTest : BaseBusinessTest
    {
        [TestMethod]
        public void Cadastrar_ValidObject_DoesntThrowException()
        {
            new AnuncioFotoBusiness().Cadastrar(7, 1, "6b9659dc-16eb-b558-6149-166033ed26f4", 1);
        }

        [TestMethod]
        public void TratarCaminhoImagem_ValidPath_ReturnCorrect()
        {
            var path = AnuncioFotoBusiness.TratarCaminhoImagem(@"D:\Documents\Git\pets\PetSaver.Site\anuncios\6b9659dc-16eb-b558-6149-166033ed26f4\1.jpeg");

            Assert.IsTrue(path == "anuncios/6b9659dc-16eb-b558-6149-166033ed26f4/1.jpeg");
        }
    }
}
