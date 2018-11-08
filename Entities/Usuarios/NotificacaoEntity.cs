namespace PetSaver.Entity.Usuarios
{
    public class NotificacaoEntity : BaseEntity
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
