namespace PetSaver.Entity.Usuarios
{
    public class HistoricoNotificacaoEntity : BaseEntity
    {
        /// <summary>
        /// Id da notificação
        /// </summary>
        public int IdNotificacao { get; set; }

        /// <summary>
        /// Id do usuário que recebeu a notificação
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Id do anúncio a que a notificação faz referência
        /// </summary>
        public int? IdAnuncio { get; set; }
    }
}
