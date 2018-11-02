using System;

namespace PetSaver.Entity.Usuarios
{
    public class LoginEntity : BaseEntity
    {
        #region .: Propriedades Herdadas :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }
        public override int IdLoginCadastro { get; set; }

        public override DateTime? DataAlteracao { get; set; }
        public override int? IdLoginAlteracao { get; set; }

        #endregion

        #region .: Propriedades próprias :.

        /// <summary>
        /// Email do login
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do login
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Tipo do login. Ex.: Usuário, Funcionário, etc
        /// </summary>
        public int IdTipo { get; set; } 

        #endregion
    }
}
