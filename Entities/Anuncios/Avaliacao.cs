namespace Entities.Anuncios
{
    public class Avaliacao : BaseEntity
    {
        /// <summary>
        /// Nota da avaliação
        /// </summary>
        public int Nota { get; set; }

        /// <summary>
        /// Comentário referente à avaliação
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Id do interesse que originou essa avaliação
        /// </summary>
        public int IdInteresse { get; set; }

        /// <summary>
        /// Id do usuário que realizou a avaliação
        /// </summary>
        public int IdAvaliador { get; set; }

        /// <summary>
        /// Id do usuário que foi avaliado
        /// </summary>
        public int IdAvaliado { get; set; }
    }
}
