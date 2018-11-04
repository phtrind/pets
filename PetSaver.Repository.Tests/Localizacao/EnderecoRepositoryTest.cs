using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Localizacao;
using PetSaver.Repository.Localizacao;

namespace PetSaver.Repository.Tests.Localizacao
{
    [TestClass]
    public class EnderecoRepositoryTest : BaseRepositoryTest
    {
        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidEndereco_DoesntThrowException()
        {
            var usuario = new EnderecoEntity()
            {
                Logradouro = "Rua Conde Santa Marinha",
                Numero = "385",
                Complemento = "Apto 703",
                Bairro = "Cachoeirinha",
                Cep = "31130080",
                IdCidade = 1,
                IdEstado = 1,
                IdLoginCadastro = 1,
            };

            var codigo = new EnderecoRepository().Inserir(usuario);

            Assert.IsTrue(codigo > 0);
        }

        #endregion
    }
}
