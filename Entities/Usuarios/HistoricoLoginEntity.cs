using System;

namespace PetSaver.Entity.Usuarios
{
    public class HistoricoLoginEntity : BaseEntity
    {
        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        /// <summary>
        /// Id do login
        /// </summary>
        public int IdLogin { get; set; }
    }
}
