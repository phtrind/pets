using System;

namespace PetSaver.Entity.Anuncios
{
    public class AvaliacaoEntity : BaseEntity
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
        /// Nota da avaliação
        /// </summary>
        public int Nota { get; set; }

        /// <summary>
        /// Comentário referente à avaliação
        /// </summary>
        public string Descricao { get; set; }

        #endregion

        #region .: Foreign Keys :.

        /// <summary>
        /// Id do interesse que originou essa avaliação
        /// </summary>
        public int IdInteresse { get; set; }

        /// <summary>
        /// Id do usuário que realizou a avaliação
        /// </summary>
        public int IdAvaliador { get; set; }

        /// <summary>
        /// Id do usuário que foi avaliado
        /// </summary>
        public int IdAvaliado { get; set; }

        #endregion
    }
}
