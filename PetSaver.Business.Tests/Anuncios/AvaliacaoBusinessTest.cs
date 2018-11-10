using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Business.Anuncios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Business.Tests.Anuncios
{
    [TestClass]
    public class AvaliacaoBusinessTest : BaseBusinessTest
    {
        [TestMethod]
        public void MediaAvaliacaoPorUsuario_ExistingAvaliacao_ReturnsMedia()
        {
            Assert.IsNotNull(new AvaliacaoBusiness().MediaAvaliacaoPorUsuario(4));
        }
    }
}
