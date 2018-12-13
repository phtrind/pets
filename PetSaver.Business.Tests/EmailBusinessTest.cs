using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PetSaver.Business.Tests
{
    [TestClass]
    public class EmailBusinessTest
    {
        [TestMethod]
        public void AnuncioAprovado_ValidEmail_SendsEmail()
        {
            new EmailBusiness().AnuncioAprovado(1, "phtrind@hotmail.com");
            //new EmailBusiness().AnuncioAprovado(1, "brunomarcos.s.lima@gmail.com");
        }

        [TestMethod]
        public void CadastroUsuarioAprovado_ValidEmail_SendsEmail()
        {
            new EmailBusiness().CadastroUsuarioAprovado("brunomarcos.s.lima@hotmail.com");
        }
    }
}
