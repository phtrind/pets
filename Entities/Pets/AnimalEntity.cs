using System;

namespace PetSaver.Entity
{
    public class AnimalEntity : BaseEntity
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
        /// Nome do animal. Ex.: Cachorro, Gato, Coelho
        /// </summary>
        public string Nome { get; set; }

        #endregion

        #region .: Foreign Keys :.

        /// <summary>
        /// Id do tipo do animal. Ex.: Mamífero, Réptil, etc
        /// </summary>
        public int? IdTipo { get; set; } 

        #endregion
    }
}
