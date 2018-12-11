using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PetSaver.Business.Tests
{
    [TestClass]
    public class EmailBusinessTest
    {
        [TestMethod]
        public void AnuncioPublicado_ValidEmail_SendsEmail()
        {
            new EmailBusiness().AnuncioPublicado(1, "cayres@webmz.com");
        }
    }
}
