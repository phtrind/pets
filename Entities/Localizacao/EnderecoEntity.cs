using System;

namespace PetSaver.Entity.Localizacao
{
    public class EnderecoEntity : BaseEntity
    {
        #region .: Propriedades Herdadas :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        /// <summary>
        /// Logradouro do endereço
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do endereço
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Complemento do endereço. Ex.: Apto 703
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro do endereço
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// CEP do endereço
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Id da cidade do endereço
        /// </summary>
        public int IdCidade { get; set; }

        /// <summary>
        /// Id do estado do endereço
        /// </summary>
        public int IdEstado { get; set; }
    }
}
