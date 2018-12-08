using System;

namespace PetSaver.Entity.Chat
{
    public class InboxEntity : BaseEntity
    {
        #region .: Base Entity :.

        public override int Id { get; set; }

        public override DateTime DataCadastro { get; set; }

        #endregion

        #region .: Foreign Keys :.

        /// <summary>
        /// Id do interesse à que essa mensagem se refere
        /// </summary>
        public int IdInteresse { get; set; } 

        /// <summary>
        /// Id do usuário que enviou a mensagem
        /// </summary>
        public int IdRemetente { get; set; }

        /// <summary>
        /// Id do usuário que recebeu a mensagem
        /// </summary>
        public int IdDestinatário { get; set; }

        #endregion

        #region .: Atributos :.

        /// <summary>
        /// Conteúdo da mensagem
        /// </summary>
        public string Mensagem { get; set; } 

        /// <summary>
        /// Se a mensagem já foi lida ou não
        /// </summary>
        public bool FoiLida { get; set; } 

        #endregion
    }
}
