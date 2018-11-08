using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PetSaver.Entity.Localizacao;
using PetSaver.Repository.Localizacao;
using System.Collections.Generic;
using System.IO;
using System.Transactions;

namespace PetSaver.Repository.Tests.Localizacao
{
    [TestClass]
    public class EstadoRepositoryTest : BaseRepositoryTest
    {
        #region .: Carga :.

        [TestMethod]
        public void CarregarBase_BaseIbge_DoesntThrowException()
        {
            string path = @"D:\Documents\Git\CostaAlmeidaCobranca\WebSite\js\estados_cidades.json";

            Root root;

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                root = JsonConvert.DeserializeObject<Root>(json);
            }

            var estadoRepository = new EstadoRepository();
            var cidadeRepository = new CidadeRepository();

            using (var transation = new TransactionScope())
            {
                foreach (var estado in root.estados)
                {
                    var estadoEntity = new EstadoEntity()
                    {
                        IdLoginCadastro = 1,
                        Nome = estado.nome,
                        Sigla = estado.sigla
                    };

                    var idEstado = estadoRepository.Inserir(estadoEntity);

                    foreach (var cidade in estado.cidades)
                    {
                        var cidadeEntity = new CidadeEntity()
                        {
                            IdLoginCadastro = 1,
                            IdEstado = idEstado,
                            Nome = cidade
                        };

                        cidadeRepository.Inserir(cidadeEntity);
                    }
                }

                transation.Complete();
            }
        }

        #endregion

        #region .: Cadastro :.

        [TestMethod]
        public void Inserir_ValidEstado_DoesntThrowException()
        {
            var usuario = new EstadoEntity()
            {
                Sigla = "MG",
                Nome = "Minas Gerais",
                IdLoginCadastro = 1,
            };

            var codigo = new EstadoRepository().Inserir(usuario);

            Assert.IsTrue(codigo > 0);
        }

        #endregion
    }

    public class Root
    {
        public List<Estado> estados { get; set; }
    }

    public class Estado
    {
        public string sigla { get; set; }
        public string nome { get; set; }
        public List<string> cidades { get; set; }
    }
}
