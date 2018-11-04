using System;

namespace PetSaver.Entity.Usuarios
{
    public class FuncionarioEntity : PessoaEntity
    {
        #region .: Atributos :.

        /// <summary>
        /// Data em que o funcionário foi admitido
        /// </summary>
        public DateTime DataAdmissao { get; set; } 

        #endregion

        #region .: Foreign Key :.

        /// <summary>
        /// Id do endereço da pessoa
        /// </summary>
        public override int? IdEndereco { get; set; }

        /// <summary>
        /// Id do login da pessoa
        /// </summary>
        public override int IdLogin { get; set; }

        /// <summary>
        /// Id do tipo do funcionário, relativo ao nível de acesso. Ex.: Básico, Admin, etc
        /// </summary>
        public override int IdTipo { get; set; }

        #endregion
    }
}
