using System;

namespace PetSaver.Entity.Anuncios
{
    public class AnuncioVisitaEntity : BaseEntity
    {
        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }

        #endregion

        #region .: Foreign Keys :.

        /// <summary>
        /// Id do usuário que visitou o anúncio
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Id do anúncio visitado
        /// </summary>
        public int IdAnuncio { get; set; } 

        #endregion
    }
}
