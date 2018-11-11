using System;

namespace PetSaver.Entity.Anuncios
{
    public class AnuncioStatusEntity : BaseEntity
    {
        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        #region .: Atributos :.

        /// <summary>
        /// Descrição do status do anúncio
        /// </summary>
        public string Descricao { get; set; }

        #endregion
    }
}
