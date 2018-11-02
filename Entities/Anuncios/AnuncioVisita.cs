namespace Entities.Anuncios
{
    public class AnuncioVisita : BaseEntity
    {
        /// <summary>
        /// Id do usuário que visitou o anúncio
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Id do anúncio visitado
        /// </summary>
        public int IdAnuncio { get; set; }
    }
}
