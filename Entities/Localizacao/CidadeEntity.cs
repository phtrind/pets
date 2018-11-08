using System;

namespace PetSaver.Entity.Localizacao
{
    public class CidadeEntity : BaseEntity
    {
        #region .: Propriedades Herdadas :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Id do estado referente à cidade
        /// </summary>
        public int IdEstado { get; set; }
    }
}
