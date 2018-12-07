﻿using System;

namespace PetSaver.Entity.Base
{
    public class HistoricoStatusEntity : BaseEntity
    {
        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        #region .: Foreign Keys :.

        /// <summary>
        /// Entidade do status. Ex.: Anúncio, Interesse, Contribuição, etc
        /// </summary>
        public int IdEntidade { get; set; }

        /// <summary>
        /// Id do status. Ex.: Ativo, Pendente, etc
        /// </summary>
        public int IdStatus { get; set; }

        #endregion
    }
}
