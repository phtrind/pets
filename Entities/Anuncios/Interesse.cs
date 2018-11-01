namespace Entities.Anuncios
{
    public class Interesse : BaseEntity
    {
        public int IdUsuario { get; set; }
        public int IdAnuncio { get; set; }
        public int IdStatus { get; set; }
    }
}
