using System;

namespace PetSaver.Entity.Pets
{
    public class RacaEspecieEntity : BaseEntity
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
        /// Nome da raça. Ex.: Viralata, Pug, etc
        /// </summary>
        public string Nome { get; set; }

        #endregion

        #region .: Foreign Keys :.

        /// <summary>
        /// Id do animal. Ex.: Cachorro, Gato, etc
        /// </summary>
        public int IdAnimal { get; set; } 

        #endregion
    }
}
