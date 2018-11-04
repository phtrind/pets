using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSaver.Entity.Localizacao;
using PetSaver.Exceptions;
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
            var endereco = new EnderecoEntity()
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

            var codigo = new EnderecoRepository().Inserir(endereco);

            Assert.IsTrue(codigo > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O logradouro do endereço é inválido.")]
        public void Inserir_InvalidLogradouro_ThrowException()
        {
            var endereco = new EnderecoEntity()
            {
                Numero = "385",
                Complemento = "Apto 703",
                Bairro = "Cachoeirinha",
                Cep = "31130080",
                IdCidade = 1,
                IdEstado = 1,
                IdLoginCadastro = 1,
            };

            new EnderecoRepository().Inserir(endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O bairro do endereço é inválido.")]
        public void Inserir_InvalidBairro_ThrowException()
        {
            var endereco = new EnderecoEntity()
            {
                Logradouro = "Rua Conde Santa Marinha",
                Numero = "385",
                Complemento = "Apto 703",
                Cep = "31130080",
                IdCidade = 1,
                IdEstado = 1,
                IdLoginCadastro = 1,
            };

            new EnderecoRepository().Inserir(endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O cep do endereço é inválido.")]
        public void Inserir_InvalidCep_ThrowException()
        {
            var endereco = new EnderecoEntity()
            {
                Logradouro = "Rua Conde Santa Marinha",
                Numero = "385",
                Complemento = "Apto 703",
                Bairro = "Cachoeirinha",
                Cep = "",
                IdCidade = 1,
                IdEstado = 1,
                IdLoginCadastro = 1,
            };

            new EnderecoRepository().Inserir(endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O Id da cidade do endereço é inválido.")]
        public void Inserir_NonexistentCidade_ThrowException()
        {
            var endereco = new EnderecoEntity()
            {
                Logradouro = "Rua Conde Santa Marinha",
                Numero = "385",
                Complemento = "Apto 703",
                Bairro = "Cachoeirinha",
                Cep = "31130080",
                IdCidade = 100,
                IdEstado = 1,
                IdLoginCadastro = 1,
            };

            new EnderecoRepository().Inserir(endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException), "O Id da cidade do endereço é inválido.")]
        public void Inserir_WithoutCidade_ThrowException()
        {
            var endereco = new EnderecoEntity()
            {
                Logradouro = "Rua Conde Santa Marinha",
                Numero = "385",
                Complemento = "Apto 703",
                Bairro = "Cachoeirinha",
                Cep = "31130080",
                IdEstado = 1,
                IdLoginCadastro = 1,
            };

            new EnderecoRepository().Inserir(endereco);
        }

        #endregion
    }
}
