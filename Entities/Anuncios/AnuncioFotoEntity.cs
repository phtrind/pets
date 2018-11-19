using System;

namespace PetSaver.Entity.Anuncios
{
    public class AnuncioFotoEntity : BaseEntity
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
        /// Id do anúncio referente à foto
        /// </summary>
        public int IdAnuncio { get; set; }

        #endregion

        #region .: Atributos :.

        public string Caminho { get; set; }
        public bool Destaque { get; set; }

        #endregion
    }
}
