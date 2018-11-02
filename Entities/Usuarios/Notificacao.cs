namespace Entities.Usuarios
{
    public class Notificacao : BaseEntity
    {
        /// <summary>
        /// Título da notificação
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Mensagem da notificação
        /// </summary>
        public string Descricao { get; set; }
    }
}
