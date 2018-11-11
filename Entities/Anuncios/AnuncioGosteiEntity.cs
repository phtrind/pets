using System;

namespace PetSaver.Entity.Anuncios
{
    public class AnuncioGosteiEntity : BaseEntity
    {
        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        #region .: Foreign Keys :.

        public int IdAnuncio { get; set; }
        public int IdUsuario { get; set; }

        #endregion
    }
}
