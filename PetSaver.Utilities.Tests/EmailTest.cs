using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Utilities.Tests
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public async Task EnviarEmail_ValidEmail_SendEmailAsync()
        {
            var emailEntity = new Email();
            
            await emailEntity.EnviarEmail("Assunto", "Conteudo", "phtrind@hotmail.com", false);
        }
    }
}
