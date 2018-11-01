namespace Entities.Usuarios
{
    public class HistoricoNotificacao : BaseEntity
    {
        public int IdUsuario { get; set; }
        public int IdNotificacao { get; set; }
        public int? IdAnuncio { get; set; }
    }
}
