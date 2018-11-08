using System;

namespace PetSaver.Entity.Localizacao
{
    public class LocalizacaoEntity : BaseEntity
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
        /// Longitude da localização
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude da localização
        /// </summary>
        public double Latitude { get; set; }

        #endregion
    }
}
