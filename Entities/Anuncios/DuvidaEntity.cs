using System;

namespace PetSaver.Entity.Anuncios
{
    public class DuvidaEntity : BaseEntity
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
        /// Descrição da pergunta
        /// </summary>
        public string Pergunta { get; set; }

        /// <summary>
        /// Descrição da resposta
        /// </summary>
        public string Resposta { get; set; }

        /// <summary>
        /// Data e hora da resposta
        /// </summary>
        public DateTime? DataHoraResposta { get; set; }

        #endregion

        #region .: Foreign Keys :.

        /// <summary>
        /// Id do usuário que fez a pergunta
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Id do anúncio à que essa pergunta se refere
        /// </summary>
        public int IdAnuncio { get; set; }

        #endregion
    }
}
