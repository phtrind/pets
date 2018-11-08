using System;

namespace PetSaver.Entity.Usuarios
{
    public class TipoLoginEntity : TipoEntity
    {
        #region .: Propriedades Herdadas :.

        #region .: BaseEntity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        #region .: TipoEntity :.

        public override string Descricao { get; set; }

        #endregion

        #endregion
    }
}
