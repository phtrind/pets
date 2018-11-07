﻿using System;

namespace PetSaver.Entity.Pets
{
    public class CorEntity : BaseEntity
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
        /// Nome da cor. Ex.: Amarelo, Verde, etc
        /// </summary>
        public string Nome { get; set; } 

        #endregion
    }
}
