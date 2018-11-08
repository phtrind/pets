using System;

namespace PetSaver.Entity.Anuncios
{
    public class InteresseEntity : BaseEntity
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
        /// Id do usuário interessado no anúncio
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Id do anúncio que originou o interesse
        /// </summary>
        public int IdAnuncio { get; set; }

        /// <summary>
        /// Id do status atual do interesse. Ex.: Ativo, Finalizado, etc.
        /// </summary>
        public int IdStatus { get; set; } 

        #endregion
    }
}
