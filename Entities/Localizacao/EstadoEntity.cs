using System;

namespace PetSaver.Entity.Localizacao
{
    public class EstadoEntity : BaseEntity
    {
        #region .: Propriedades Herdadas :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        /// <summary>
        /// Sigla do estado. Ex.: MG, SP, etc
        /// </summary>
        public string Sigla { get; set; }

        /// <summary>
        /// Nome do estado
        /// </summary>
        public string Nome { get; set; }
    }
}
