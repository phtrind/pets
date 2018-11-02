namespace Entities
{
    public class Animal : BaseEntity
    {
        /// <summary>
        /// Nome do animal. Ex.: Cachorro, Gato, Coelho
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Id do tipo do animal. Ex.: Mamífero, Réptil, etc
        /// </summary>
        public int IdTipo { get; set; }
    }
}
