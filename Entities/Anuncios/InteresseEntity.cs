namespace PetSaver.Entity.Anuncios
{
    public class InteresseEntity : BaseEntity
    {
        /// <summary>
        /// Id do usuário interessado no anúncio
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Id do anúncio que originou o interesse
        /// </summary>
        public int IdAnuncio { get; set; }

        /// <summary>
        /// Id do status atual do interesse. Ex.: Ativo, Finalizado, etc.
        /// </summary>
        public int IdStatus { get; set; }
    }
}
