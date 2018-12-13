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
            new EmailBusiness().AnuncioAprovado(1, "phtrind@hotmail.com"); //brunomarcos.s.lima@gmail.com
            //new EmailBusiness().AnuncioAprovado(1, "brunomarcos.s.lima@gmail.com");
        }

        [TestMethod]
        public void CadastroUsuarioAprovado_ValidEmail_SendsEmail()
        {
            new EmailBusiness().CadastroUsuarioAprovado("phtrind@hotmail.com");
        }

        [TestMethod]
        public void AlteracaoStatusAnuncio_ValidEmail_SendsEmail()
        {
            new EmailBusiness().AlteracaoStatusAnuncio("phtrind@hotmail.com");
        }
    }
}
