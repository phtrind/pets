namespace Entities.Anuncios
{
    public class Anuncio : BaseEntity
    {
        public int IdUsuario { get; set; }
        public int IdStatus { get; set; }
        public int IdTipo { get; set; }
        public int IdPet { get; set; }
        public int IdLocalizacao { get; set; }
        public int IdEstado { get; set; }
        public int IdCidade { get; set; }
    }
}
