using System;

namespace PetSaver.Entity.Pets
{
    public class SexoEntity : BaseEntity
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
        /// Descrição do sexo. Ex.: Macho, Fêmea
        /// </summary>
        public string Descricao { get; set; } 

        #endregion
    }
}
