﻿namespace PetSaver.Entity.Base
{
    public class HistoricoStatusEntity : BaseEntity
    {
        /// <summary>
        /// Entidade do status. Ex.: Anúncio, Interesse, Contribuição, etc
        /// </summary>
        public int IdEntidade { get; set; }

        /// <summary>
        /// Id do status. Ex.: Ativo, Pendente, etc
        /// </summary>
        public int IdStatus { get; set; }
    }
}
