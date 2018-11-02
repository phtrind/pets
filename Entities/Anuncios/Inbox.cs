namespace Entities.Anuncios
{
    public class Inbox : BaseEntity
    {
        /// <summary>
        /// Descrição da mensagem enviada
        /// </summary>
        public string Mensagem { get; set; }

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
    }
}
